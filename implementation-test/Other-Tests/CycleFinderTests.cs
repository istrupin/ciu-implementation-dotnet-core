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
        private SleeveGroupService sleeveGroupService;
        private List<SleeveGroup> sleeveGroups;
        private List<SleeveGroupRelationship> existingRelationships;
        public CycleFinder_Should()
        {
            sleeveGroups = new List<SleeveGroup>() { new SleeveGroup(0), new SleeveGroup(1), new SleeveGroup(2), new SleeveGroup(3), new SleeveGroup(4), new SleeveGroup(5) };
            existingRelationships = new List<SleeveGroupRelationship>()
            {
                new SleeveGroupRelationship() { Parent = sleeveGroups[0], Child = sleeveGroups[1] },
                new SleeveGroupRelationship() { Parent = sleeveGroups[0], Child = sleeveGroups[2] },
                new SleeveGroupRelationship() { Parent = sleeveGroups[2], Child = sleeveGroups[3] },
                new SleeveGroupRelationship() { Parent = sleeveGroups[1], Child = sleeveGroups[3] },
                new SleeveGroupRelationship() { Parent = sleeveGroups[1], Child = sleeveGroups[4] },
                new SleeveGroupRelationship() { Parent = sleeveGroups[1], Child = sleeveGroups[5] }
            };
            sleeveGroupService = new SleeveGroupService(existingRelationships);
        }

        [Fact]
        public void AddValidItems()
        {
            sleeveGroupService.AddSleeveGroupRelationship(new SleeveGroupRelationship() { Parent = sleeveGroups[4], Child = sleeveGroups[5] });
            sleeveGroupService.SleeveGroupRelationships.Count.ShouldBe(7);
            sleeveGroupService.SleeveGroupRelationships.Last().Parent.ShouldBe(sleeveGroups[4]);
        }

        [Fact]
        public void ShouldFailToAddCircularReference()
        {
            Should.Throw<ArgumentException>(() => sleeveGroupService.AddSleeveGroupRelationship(new SleeveGroupRelationship() { Parent = sleeveGroups[5], Child = sleeveGroups[0] }));
        }
    }
}