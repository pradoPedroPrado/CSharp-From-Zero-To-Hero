﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BootCamp.Chapter
{
    public static class PeoplePredicates
    {
        /// <summary>
        /// a) over 18, who do not live in UK, whose surename does not contain letter 'a'.
        /// </summary>
        /// <returns></returns>
        public static bool IsA(Person person)
        {
            bool isOver18 = (person.Age >= 18);
            bool doesntLiveInUK = !person.Country.Equals("United Kingdom");
            bool doesntContainsA = !person.SureName.ToLower().Contains('a');
            return isOver18 && doesntLiveInUK && doesntContainsA;
        }

        /// <summary>
        /// b) under 18,  who do not live in UK, whose surename does not contain letter 'a'.  
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static bool IsB(Person person) => false;

        /// <summary>
        /// c) who do not live in UK, whose surename and name does not contain letter 'a'.  
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static bool IsC(Person person) => false;
    }
}
