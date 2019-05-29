using System;
using System.Collections.Generic;
using System.Linq;
using implementation.other.CycleFinder;
using Shouldly;
using Xunit;

namespace implementation_test.Other_Tests
{
    public class CycleFinder_Should
    {
        private CycleFinderService cycleFinder;
        private List<Entity> entities;
        private List<ParentChildRelationship> existingRelationships;
        public CycleFinder_Should()
        {
            entities = new List<Entity>() { new Entity(0), new Entity(1), new Entity(2), new Entity(3), new Entity(4), new Entity(5) };
            existingRelationships = new List<ParentChildRelationship>()
            {
                new ParentChildRelationship() { Parent = entities[0], Child = entities[1] },
                new ParentChildRelationship() { Parent = entities[0], Child = entities[2] },
                new ParentChildRelationship() { Parent = entities[2], Child = entities[3] },
                new ParentChildRelationship() { Parent = entities[1], Child = entities[3] },
                new ParentChildRelationship() { Parent = entities[1], Child = entities[4] },
                new ParentChildRelationship() { Parent = entities[1], Child = entities[5] }
            };
            cycleFinder = new CycleFinderService(existingRelationships);
        }

        [Fact]
        public void AddValidItems()
        {
            cycleFinder.AddParentChildRelationship(new ParentChildRelationship() { Parent = entities[4], Child = entities[5] });
            cycleFinder.ParentChildRelationships.Count.ShouldBe(7);
            cycleFinder.ParentChildRelationships.Last().Parent.ShouldBe(entities[4]);
        }

        [Fact]
        public void ShouldFailToAddCircularReference()
        {
            Should.Throw<ArgumentException>(() => cycleFinder.AddParentChildRelationship(new ParentChildRelationship() { Parent = entities[5], Child = entities[0] }));
        }
    }
}