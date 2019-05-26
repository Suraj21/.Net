using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVM.Enums
{
    /// <summary>
    /// Represents a valid bit rate for a digital audio file.
    /// </summary>
    public enum BitRate
    {
        /// <summary>
        /// Represents a bit rate of 16 bits per sample.
        /// </summary>
        [Description("16 bits")]
        Sixteen = 16,
        /// <summary>
        /// Represents a bit rate of 24 bits per sample.
        /// </summary>
        [Description("24 bits")]
        TwentyFour = 24,
        /// <summary>
        /// Represents a bit rate of 32 bits per sample.
        /// </summary>
        [Description("32 bits")]
        ThirtyTwo = 32,
        /// <summary>
        /// Represents a bit rate of 32 bits per sample.
        /// </summary>
        [Description("64 bits")]
        SixtyFour = 64,
    }
}
