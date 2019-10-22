using System;
using System.Collections.Generic;
using System.Linq;

namespace implementation.Algorithms
{
    public class Knapsack
    {
        public Knapsack(IEnumerable<int> itemValues, IEnumerable<int> itemWeights, int capacity)
        {
            ValidateParameters(itemValues, itemWeights);
            _itemValues = itemValues.ToArray();
            _itemWeights = itemWeights.ToArray();
            _capacity = capacity;
            WeightValueMatrix = new int[itemValues.Count() + 1, capacity + 1];
            FillWeightValueMatrix();
            SetMaxValue();
        }

        //[items, weights]
        public int[,] WeightValueMatrix {get; private set;}
        private readonly int[] _itemValues;
        private readonly int[] _itemWeights;
        private readonly int _capacity;
        public int MaximizedValue {get; private set;}

        public IEnumerable<int> GetSelectedItems(){
            //start with bottom right most quadrant
            var value = WeightValueMatrix[_itemValues.Length, _capacity];
            var capacityIndex = _capacity;
            for (int itemIndex = _itemValues.Length; itemIndex > 0 && value > 0; itemIndex--)
            {
                if (CurrentValueDifferentFromPreviousValue(value, itemIndex, capacityIndex)){
                    yield return itemIndex;
                    value -= GetItemValue(itemIndex);
                    capacityIndex -= GetItemWeight(itemIndex);
                }
            }
        }

        private bool CurrentValueDifferentFromPreviousValue(int currentItemValue, int currentItemIndex, int capacityIndex) 
            => currentItemValue != GetPreviousItemValueForCapacity(currentItemIndex, capacityIndex);
        private void FillWeightValueMatrix(){
            //start at 1 because first row should be all 0s
            for (int itemIndex = 1; itemIndex <= _itemValues.Count(); itemIndex++)
            {
                //start at 1 because first column should be all 0s
                for (int currentCapacity = 1; currentCapacity <= _capacity; currentCapacity++)
                {
                    var maxValueWithoutCurrent = GetPreviousItemValueForCapacity(itemIndex, currentCapacity);
                    var currentItemWeight = GetItemWeight(itemIndex);
                    int maxValueWithCurrent = 0;
                    if (currentCapacity >= currentItemWeight)
                    {
                        //at least the value of the current item
                        maxValueWithCurrent = GetItemValue(itemIndex);
                        var remainingCapacity = currentCapacity - currentItemWeight;
                        //if there is any capacity left, select max value for that capacity not including
                        //current item (since we've already included it)
                        var marginalValue = GetPreviousItemValueForCapacity(itemIndex, remainingCapacity);
                        maxValueWithCurrent += marginalValue;
                        // TryAddItem(maxValueWithCurrent, maxValueWithoutCurrent, itemIndex);
                    }
                    WeightValueMatrix[itemIndex, currentCapacity] = Math.Max(maxValueWithoutCurrent, maxValueWithCurrent);
                }
            }
        }
        private void SetMaxValue()
        {
            MaximizedValue = WeightValueMatrix[_itemValues.Length, _capacity];
        }

        private int GetBottomRightCornerOfMatrix() => WeightValueMatrix[WeightValueMatrix.GetLength(0), WeightValueMatrix.GetLength(1)];

        //-1 because array is zero based and we are using 1 based for
        private int GetItemWeight(int itemIndex) => _itemWeights[itemIndex - 1];
        private int GetItemValue(int itemIndex) => _itemValues[itemIndex - 1];

        private int GetPreviousItemValueForCapacity(int currentItemIndex, int capacity) => WeightValueMatrix[currentItemIndex - 1, capacity];
        private void ValidateParameters(IEnumerable<int> itemValues, IEnumerable<int> itemWeights)
        {
            if (itemValues.Count() != itemWeights.Count())
            {
                throw new Exception("Item values and item weights must be of the same length.");
            }
        }

    }
}