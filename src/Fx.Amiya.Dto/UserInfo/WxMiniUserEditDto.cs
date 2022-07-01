﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.UserInfo
{
    /// <summary>
    ///  微信小程序用户
    /// </summary>
   public class WxMiniUserEditDto
    {
        public string OpenId { get; set; }

        public string UnionId { get; set; }

        public string NickName { get; set; }
        public string AvatarUrl { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public byte Gender { get; set; }
        public string Language { get; set; }
    }
}
