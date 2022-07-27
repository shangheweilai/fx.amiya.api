﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.Core
{
    public class TikTokOrder
    {
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string Phone { get; set; }
        public string AppointmentHospital { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// 价格（商品正常价格）
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 应收款（优惠后实际价格，财务用）
        /// </summary>
        public decimal? AccountReceivable { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public string ThumbPicUrl { get; set; }
        public string BuyerNick { get; set; }
        public byte AppType { get; set; }
        public bool IsAppointment { get; set; }
        //  public string Type { get; set; }

        /// <summary>
        /// 订单类型：0、普通订单 2、虚拟商品订单 4、电子券（poi核销） 5、三方核销
        /// </summary>
        public long OrderType { get; set; }
        public int Quantity { get; set; }
        public string TikTokUserId { get; set; }
        public string CipherPhone { get; set; }
        public string CipherName { get; set; }
    }
}