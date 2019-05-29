using System;
using System.Collections.Generic;
using System.Linq;

namespace implementation.other.CycleFinder
{
    public class CycleFinderService
    {
        public List<ParentChildRelationship> ParentChildRelationships { get; private set; }
        public CycleFinderService(List<ParentChildRelationship> existingRelationships)
        {
            ParentChildRelationships = existingRelationships;
        }

        public void AddParentChildRelationship(ParentChildRelationship parentChildRelationship)
        {
            if (RelationshipCreatesCycle(parentChildRelationship))
            {
                throw new ArgumentException($"Adding {parentChildRelationship.Parent.Id}->{parentChildRelationship.Child.Id} relationship would create a circular reference.");
            }
            ParentChildRelationships.Add(parentChildRelationship); // store in DB
        }

        private bool RelationshipCreatesCycle(ParentChildRelationship parentChildRelationship)
        {
            return AnyDescendantEquals(parentChildRelationship.Parent, parentChildRelationship);
        }

        private bool AnyDescendantEquals(Entity condition, ParentChildRelationship childToTest, HashSet<int> visitedIds = null)
        {
            var visited = visitedIds ?? new HashSet<int>();
            if (childToTest.Child.Id == condition.Id)
            {
                return true;
            }
            visited.Add(childToTest.Child.Id);
            var childrenOfChildToTest = ParentChildRelationships.Where(x => x.Parent.Id == childToTest.Child.Id);
            return childrenOfChildToTest.Any(r => !visited.Contains(r.Child.Id) && AnyDescendantEquals(condition, r, visited));
        }   
    }
}