using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessWebApp.Models
{
    public class MiniUser
    {
        public int UID { get; set; }
        public string TellNumber { get; set; }
        public string Email { get; set; }
        public int Credit { get; set; }
        public System.DateTime JoinDate { get; set; }
        public System.DateTime LastLogin { get; set; }
        public int RewardState { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string NickName { get; set; }
        public string CodeMeli { get; set; }
    }
}