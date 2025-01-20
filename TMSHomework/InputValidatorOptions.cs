using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    public class InputValidatorOptions
    {
        private static readonly int _minLoginLength = 3;
        private static readonly int _maxLoginLength = 19;
        private static readonly int _minPasswordLength = 6;
        private static readonly int _maxPasswordLength = 19;
        public static string LoginPattern { get; private set; } = $@"^\w{{{_minLoginLength},{_maxLoginLength}}}$";
        public static string PasswordPattern { get; private set; } = $@"^(?=.*\d).{{{_minPasswordLength},{_maxPasswordLength}}}$";
    }
}
