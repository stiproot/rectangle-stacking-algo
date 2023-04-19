using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace RectangleFactoryAPI.Helpers
{
    public static class InputValidationHelper
    {
        public static bool validateMyRectangleAlgorithmInput(MyRectangleAlgorithmInput input)
        {
            int min = ConfigHelper<int>.getValue("MyRectangleAlgorithmMinInputRequest");
            int max = ConfigHelper<int>.getValue("MyRectangleAlgorithmMaxInputRequest");

            if (input.rectangleCreationNumber < min || input.rectangleCreationNumber > max)
            {
                throw new Exception($"The number of rectangles created must be greater than or equal to {min} and less than or equal to {max}");
            }

            return true;
        }
    }
}