using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.ProgramSettingList
{
    public class ProgramSetting
    {
        public int Id { get; set; }
        public bool Enable2FA { get; set; }
        public int FaType { get; set; }
    }
}
