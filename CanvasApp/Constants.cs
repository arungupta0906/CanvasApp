using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp
{
    public class Constants
    {
        public static string Line_Out_Of_Canvas_Boundaries = "$This line is out of canvas boundaries and cannot be drawn";

        public static string Rectangle_Out_Of_Canvas_Boundaries = $"This rectangle is out of canvas boundaries and cannot be drawn";

        public static string Point_Out_Of_Canvas_Boundaries = $"The target point is out of the canvas boundaries";

        public static string Command_Expect_Two_Arguments = $"This command expects 2 arguments but only received";

        public static string Command_Expect_Two_Positive_Arguments = $"There is some invalid arguments.Both arguments should be positive integers";

        public static string Command_Expect_Four_Arguments = $"This command expects 4 arguments but only received";

        public static string Command_Expect_Four_Positive_Arguments = $"There is some invalid arguments. All 4 arguments should be positive integers";

        public static string Command_Canvas_Not_Exists = $"Canvas does not exists.Please create one then try again.";

        public static string Command_Expect_Three_Arguments = $"This command expects 3 arguments but only received";

        public static string Command_Expect_Two_Positive_One_Alphanumeric_Arguments = $"There are some invalid arguments. The 2 first arguments should be positive integer and the last one should be an alphanumerical character";

    }
}
