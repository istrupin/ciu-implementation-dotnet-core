using System;
using System.Collections.Generic;
using System.Linq;
using implementation.other.cycle_finder;
using Shouldly;
using Xunit;

namespace implementation_test.Other_Tests
{
    public class CycleFinder_Should
    {
        private CycleFinderService sleeveGroupService;
        private List<Entity> sleeveGroups;
        private List<ParentChildRelationship> existingRelationships;
        public CycleFinder_Should()
        {
            sleeveGroups = new List<Entity>() { new Entity(0), new Entity(1), new Entity(2), new Entity(3), new Entity(4), new Entity(5) };
            existingRelationships = new List<ParentChildRelationship>()
            {
                new ParentChildRelationship() { Parent = sleeveGroups[0], Child = sleeveGroups[1] },
                new ParentChildRelationship() { Parent = sleeveGroups[0], Child = sleeveGroups[2] },
                new ParentChildRelationship() { Parent = sleeveGroups[2], Child = sleeveGroups[3] },
                new ParentChildRelationship() { Parent = sleeveGroups[1], Child = sleeveGroups[3] },
                new ParentChildRelationship() { Parent = sleeveGroups[1], Child = sleeveGroups[4] },
                new ParentChildRelationship() { Parent = sleeveGroups[1], Child = sleeveGroups[5] }
            };
            sleeveGroupService = new CycleFinderService(existingRelationships);
        }

        [Fact]
        public void AddValidItems()
        {
            sleeveGroupService.AddParentChildRelationship(new ParentChildRelationship() { Parent = sleeveGroups[4], Child = sleeveGroups[5] });
            sleeveGroupService.ParentChildRelationships.Count.ShouldBe(7);
            sleeveGroupService.ParentChildRelationships.Last().Parent.ShouldBe(sleeveGroups[4]);
        }

        [Fact]
        public void ShouldFailToAddCircularReference()
        {
            Should.Throw<ArgumentException>(() => sleeveGroupService.AddParentChildRelationship(new ParentChildRelationship() { Parent = sleeveGroups[5], Child = sleeveGroups[0] }));
        }
    }
}