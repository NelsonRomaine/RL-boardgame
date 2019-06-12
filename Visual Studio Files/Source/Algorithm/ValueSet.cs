﻿using System.Collections.Generic;

namespace ReinforcementLearning
{
    //This class is useful for simplifying the q-matrix
    //This class will manage the list of 5 q moves that are associated with each state in the q-matrix.
    //A valueset is a row of the q matrix.
    class ValueSet
    {
        //5 moves with q-matrix double values associated for each one
        public Dictionary<Move, double> moveList;

        public ValueSet()
        {
            moveList = new Dictionary<Move, double>();

            //Build a dictionary with 5 moves, by default
            foreach(var i in Move.HorizontalMovesAndGrab)
            {
                moveList.Add(i, 0f);
            }
        }

        public ValueSet(ValueSet set_from)
        {
            moveList = new Dictionary<Move, double>();
            foreach (var i in set_from.moveList)
            {
                moveList.Add(i.Key, i.Value);
            }
        }

        public double GetBestValue()
        {
            double toReturn = 0;
            foreach (var i in moveList.Values)
            {
                if (i > toReturn)
                    toReturn = i;
            }
            return toReturn;
        }

        public double this[Move key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                SetValue(key, value);
            }

        }

        public double GetValue(Move index)
        {
            return moveList[index];
        }

        public void SetValue(Move index, double value)
        {
            moveList[index] = value;
        }
    }
}
