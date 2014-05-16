﻿using System;
using System.Collections.Generic;

namespace RxPipeline
{
    public static class Extensions
    {
        public static void Each<T>(this IEnumerable<T> collection, Action<T> doThis)
        {
            foreach(var item in collection)
            {
                doThis(item);
            }
        }
    }
}
