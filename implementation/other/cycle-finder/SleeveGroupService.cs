using System;
using System.Collections.Generic;
using System.Linq;

namespace implementation.other.cycle_finder
{
    public class SleeveGroupService
    {
        public List<SleeveGroupRelationship> SleeveGroupRelationships { get; set; }

        public SleeveGroupService(List<SleeveGroupRelationship> existingRelationships)
        {
            SleeveGroupRelationships = existingRelationships;
        }

        public void AddSleeveGroupRelationship(SleeveGroupRelationship sleeveGroupRelationship)
        {
            if (RelationshipCreatesCycle(sleeveGroupRelationship))
            {
                throw new ArgumentException($"Adding {sleeveGroupRelationship.Parent.Id}->{sleeveGroupRelationship.Child.Id} relationship would create a circular reference.");
            }
            SleeveGroupRelationships.Add(sleeveGroupRelationship); // store in DB
        }

        private bool RelationshipCreatesCycle(SleeveGroupRelationship sleeveGroupRelationship)
        {
            return AnyDescendantEquals(sleeveGroupRelationship.Parent, sleeveGroupRelationship);
        }

        private bool AnyDescendantEquals(SleeveGroup condition, SleeveGroupRelationship childToTest, HashSet<int> visitedIds = null)
        {
            var visited = visitedIds ?? new HashSet<int>();
            if (childToTest.Child.Id == condition.Id)
            {
                return true;
            }
            visited.Add(childToTest.Child.Id);
            var childrenOfChildToTest = SleeveGroupRelationships.Where(x => x.Parent.Id == childToTest.Child.Id);
            return childrenOfChildToTest.Any(r => !visited.Contains(r.Child.Id) && AnyDescendantEquals(condition, r, visited));
        }   
    }
}