using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessWebApp.Models
{
    public class ResLastUserInfo
    {
        public MiniUser MiniUser { get; set; }
        public List<Com.UserBought> userBought { get; set; }
        public List<Com.UserBasket> userBasket { get; set; }
        public List<Com.UserMessage> userMessage { get; set; }
    }
}