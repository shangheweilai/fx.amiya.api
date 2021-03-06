-----------------------------------------------余建明 2021/06/18 BEGIN------------------------------------------
ALTER TABLE tbl_order_info ADD COLUMN Description VARCHAR(200) DEFAULT NULL COMMENT '简介' AFTER trade_id;
ALTER TABLE tbl_order_info ADD COLUMN Standard VARCHAR(100) DEFAULT NULL COMMENT '规格' AFTER Description;
ALTER TABLE tbl_order_info ADD COLUMN Parts VARCHAR(100) DEFAULT NULL COMMENT '部位' AFTER Standard;
-----------------------------------------------余建明 2021/06/18 END--------------------------------------------

-----------------------------------------------余建明 2021/07/07 BEGIN------------------------------------------
ALTER TABLE tbl_hospital_info ADD COLUMN `business_hours` VARCHAR(50)  DEFAULT NULL COMMENT '营业时间' AFTER `city_id`;

ALTER TABLE tbl_goods_info
ADD COLUMN `details_description` VARCHAR(500)  NULL AFTER `version`,
ADD COLUMN `max_show_price` DECIMAL(10,2) UNSIGNED NULL DEFAULT '0.00' AFTER `details_description`,
ADD COLUMN `min_show_price` DECIMAL(10,2) UNSIGNED NULL DEFAULT '0.00' AFTER `max_show_price`,
ADD COLUMN `visit_count` INT UNSIGNED NULL DEFAULT 0 AFTER `min_show_price`,
ADD COLUMN `sale_count` INT UNSIGNED NULL DEFAULT 0 AFTER `visit_count`,
ADD COLUMN `show_sale_count` INT UNSIGNED NULL DEFAULT 0 AFTER `sale_count`;

-----------------------------------------------余建明 2021/07/07 END--------------------------------------------



-----------------------------------------------余建明 2021/07/17 BEGIN------------------------------------------
ALTER TABLE `amiyadb`.`tbl_goods_category` 
ADD COLUMN `show_direction_type` INT NOT NULL DEFAULT 0 AFTER `update_date`;
-----------------------------------------------余建明 2021/07/17 END--------------------------------------------


-----------------------------------------------余建明 2021/07/28 BEGIN------------------------------------------

--tbl_config表修改config列【加入微分销渠道】
UPDATE `amiyadb`.`tbl_config` SET `config_json` = '{\"FxJwtConfig\":{\"Key\":\"kljdsf982734jkldg!@#\",\"ExpireInSeconds\":7200,\"RefreshTokenExpireInSeconds\":14400},\"FxOpenConfig\":{\"Enable\":true,\"RequestBaseUrl\":\"https://app.hsltm.com/fxgatetest\"},\"FxOSSConfig\":null,\"FxRedisConfig\":{\"ConnectionString\":\"app.hsltm.com:6379,allowadmin=true,password=hsltm\"},\"FxSmsConfig\":{\"AliyunSmsList\":[{\"Name\":\"send_validate_code\",\"AccessKeyId\":\"LTAIlyCdQbQnA96C\",\"AccessSecret\":\"nXtBYoUzt3nw3v5DasAjNdLliuBB0h\",\"RegionId\":\"cn_hangzhou\",\"SignName\":\"杭州华山医院\",\"TemplateCode\":\"SMS_126464576\",\"Remark\":\"发送验证码\"}]},\"FxUniteWxAccessTokenConfig\":{\"Enable\":true,\"RequestBaseUrl\":\"https://app.hsltm.com/fxwxaccesstoken\"},\"WxPayConfig\":null,\"FxMessageCenterConfig\":{\"EnableMessageCenter\":true,\"EnableMessageQueue\":true,\"MQHostName\":\"app.hsltm.com\",\"MQUserName\":\"admin\",\"Port\":5672,\"MQPassword\":\"hsltm1007\",\"MQQueueName\":\"fx_wxmp_message_queue\",\"MessageCenterWebSocketUrl\":null},\"ChatInMinute\":1440,\"CallCenterConfig\":{\"CallRecordStoreAddress\":\"mongodb://192.168.11.72:27890\",\"EnablevoiceCardCallable\":false,\"SupportOldCallBox\":false,\"SwitchSimCardInCallCount\":5,\"VoiceCardManagerAddress\":\"\",\"PhoneEncryptKey\":\"test\",\"EnablePhoneEncrypt\":true,\"HidePhoneNumber\":true},\"SyncOrderConfig\":{\"Jd\":false,\"Tmall\":true,\"WeiFenXiao\":true}}' WHERE (`id` = '1');

--tbl_order_app_info表加入微分销商户号配置
insert into amiyadb.tbl_order_app_info Values('4','4003356','a3ac5675bd09247fb89c13f60101a286','4032396','2021-07-28 11:20:22','3','2021-07-28 11:20:22',' ')

-----------------------------------------------余建明 2021/07/28 END--------------------------------------------



-----------------------------------------------余建明 2021/08/04 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_goods_category` 
ADD COLUMN `sort` INT NULL DEFAULT 0 AFTER `show_direction_type`;
-----------------------------------------------余建明 2021/08/04 END--------------------------------------------


-----------------------------------------------余建明 2021/08/10 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `write_off_code` VARCHAR(50) NULL DEFAULT NULL AFTER `Parts`,
ADD COLUMN `already_write_off_amount` INT NOT NULL DEFAULT 0 AFTER `write_off_code`;
insert into amiyadb.tbl_module Values('45','wirteoOff','订单核销',1,'/orderWriteOff','8')


--fxSmsconfig更改：AliyunSmsList加入新集合数据
UPDATE `amiyadb`.`tbl_config` SET `config_json` = '{"FxJwtConfig":{"Key":"kljdsf982734jkldg!@#","ExpireInSeconds":7200,"RefreshTokenExpireInSeconds":14400},"FxOpenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxgatetest"},"FxOSSConfig":null,"FxRedisConfig":{"ConnectionString":"app.hsltm.com:6379,allowadmin=true,password=hsltm"},"FxSmsConfig":{"AliyunSmsList":[{"Name":"send_validate_code","AccessKeyId":"LTAIlyCdQbQnA96C","AccessSecret":"nXtBYoUzt3nw3v5DasAjNdLliuBB0h","RegionId":"cn_hangzhou","SignName":"杭州华山医院","TemplateCode":"SMS_126464576","Remark":"发送验证码"},{"Name":"order_buyerpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"阿美雅","TemplateCode":"SMS_222467940","Remark":"订单下单通知"},{"Name":"order_gift_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"阿美雅","TemplateCode":"SMS_222473088","Remark":"礼品兑换通知"}]},"FxUniteWxAccessTokenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxwxaccesstoken"},"WxPayConfig":null,"FxMessageCenterConfig":{"EnableMessageCenter":true,"EnableMessageQueue":true,"MQHostName":"app.hsltm.com","MQUserName":"admin","Port":5672,"MQPassword":"hsltm1007","MQQueueName":"fx_wxmp_message_queue","MessageCenterWebSocketUrl":null},"ChatInMinute":1440,"CallCenterConfig":{"CallRecordStoreAddress":"mongodb://192.168.11.72:27890","EnablevoiceCardCallable":false,"SupportOldCallBox":false,"SwitchSimCardInCallCount":5,"VoiceCardManagerAddress":"","PhoneEncryptKey":"test","EnablePhoneEncrypt":true,"HidePhoneNumber":true},"SyncOrderConfig":{"Jd":false,"Tmall":false,"WeiFenXiao":false}}' WHERE (`id` = '1');
-----------------------------------------------余建明 2021/08/10 END--------------------------------------------


-----------------------------------------------余建明 2021/08/31 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `write_off_date` DATETIME NULL DEFAULT NULL AFTER `update_date`;
-----------------------------------------------余建明 2021/08/31 END--------------------------------------------


--------------【1.2版本更新分支数据库更改】


-----------------------------------------------余建明 2021/09/04 BEGIN--------------------------------------------

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES ('46', 'expressManage', '物流公司', 1, '/expressManage', 12);

ALTER TABLE `amiyadb`.`tbl_send_goods_record` 
ADD COLUMN `express_id` VARCHAR(50) NULL AFTER `courier_number`;

ALTER TABLE `amiyadb`.`tbl_receive_gift` 
ADD COLUMN `express_id` VARCHAR(50) NULL AFTER `address_id`;


-----------------------------------------------余建明 2021/09/04 END--------------------------------------------

-----------------------------------------------余建明 2021/09/07 BEGIN--------------------------------------------


ALTER TABLE `amiyadb`.`tbl_order_trade` 
ADD COLUMN `is_admin_add` BIT(1) NOT NULL AFTER `update_date`;

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES (47, 'hospitalDepartment', '医院科室', 1, '/hospitalDepartment', 12);
INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES (48, 'goodsDemand', '需求项目列表', 1, '/goodsDemand', 12);

ALTER TABLE `amiyadb`.`tbl_amiya_goods_demand` 
ADD COLUMN `thumb_picturl_url` VARCHAR(200) NULL AFTER `description`;


-----------------------------------------------余建明 2021/09/07 END--------------------------------------------


--------------【feature-预约到店升级】

-----------------------------------------------余建明 2021/09/10 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_appointment_info` 
DROP FOREIGN KEY `fk_appointmentinfo_orderid_order_id`;
ALTER TABLE `amiyadb`.`tbl_appointment_info` 
DROP COLUMN `order_id`,
CHANGE COLUMN `item_info_id` `item_info_name` VARCHAR(200) NULL AFTER `submit_date`,
DROP INDEX `fk_appointmentinfo_orderid_order_id` ;

ALTER TABLE `amiyadb`.`tbl_appointment_info` 
ADD COLUMN `customer_name` VARCHAR(200) NULL AFTER `customer_id`;

---------------------------------  9/14新增
ALTER TABLE `amiyadb`.`tbl_amiya_employee` 
ADD COLUMN `e_mail` VARCHAR(100) NOT NULL DEFAULT 0 AFTER `is_customer_service`;


--------------------------------9/15新增

ALTER TABLE `amiyadb`.`tbl_amiya_hospital_department` 
ADD COLUMN `sort` INT NULL DEFAULT NULL AFTER `description`;

UPDATE amiyadb.tbl_amiya_hospital_department SET SORT=1

ALTER TABLE `amiyadb`.`tbl_amiya_hospital_department` 
CHANGE COLUMN `sort` `sort` INT NOT NULL DEFAULT '0' ;


--新增阿里云sms积分兑换通知
UPDATE `amiyadb`.`tbl_config` SET `config_json` = '{"FxJwtConfig":{"Key":"kljdsf982734jkldg!@#","ExpireInSeconds":7200,"RefreshTokenExpireInSeconds":14400},"FxOpenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxgatetest"},"FxOSSConfig":null,"FxRedisConfig":{"ConnectionString":"app.hsltm.com:6379,allowadmin=true,password=hsltm"},"FxSmsConfig":{"AliyunSmsList":[{"Name":"send_validate_code","AccessKeyId":"LTAIlyCdQbQnA96C","AccessSecret":"nXtBYoUzt3nw3v5DasAjNdLliuBB0h","RegionId":"cn_hangzhou","SignName":"杭州华山医院","TemplateCode":"SMS_126464576","Remark":"发送验证码"},{"Name":"order_buyerpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"阿美雅","TemplateCode":"SMS_224341042","Remark":"订单下单通知"},{"Name":"order_intergrationpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"阿美雅","TemplateCode":"SMS_224351049","Remark":"积分兑换通知"},{"Name":"order_gift_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"阿美雅","TemplateCode":"SMS_224346105","Remark":"礼品兑换通知"}]},"FxUniteWxAccessTokenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxwxaccesstoken"},"WxPayConfig":null,"FxMessageCenterConfig":{"EnableMessageCenter":true,"EnableMessageQueue":true,"MQHostName":"app.hsltm.com","MQUserName":"admin","Port":5672,"MQPassword":"hsltm1007","MQQueueName":"fx_wxmp_message_queue","MessageCenterWebSocketUrl":null},"ChatInMinute":1440,"CallCenterConfig":{"CallRecordStoreAddress":"mongodb://192.168.11.72:27890","EnablevoiceCardCallable":false,"SupportOldCallBox":false,"SwitchSimCardInCallCount":5,"VoiceCardManagerAddress":"","PhoneEncryptKey":"test","EnablePhoneEncrypt":true,"HidePhoneNumber":true},"SyncOrderConfig":{"Jd":false,"Tmall":false,"WeiFenXiao":false}}' WHERE (`id` = '1');


--------------------------------9/22

ALTER TABLE `amiyadb`.`tbl_cooperative_hospital_city` 
ADD COLUMN `is_hot` BIT(1) NOT NULL AFTER `valid`;


ALTER TABLE `amiyadb`.`tbl_cooperative_hospital_city` 
ADD COLUMN `province_id` VARCHAR(50) NOT NULL DEFAULT '0' AFTER `is_hot`;

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES (49, 'ProvinceManage', '省份管理', 1, '/province', 12);



--------------------------------9/23

INSERT INTO `amiyadb`.`tbl_module_category` (`id`, `name`, `description`, `valid`, `path`) VALUES ('17', 'beautyDiary', '美丽日记', 1, '/beautyDiary');

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES ('50', 'BeautyDiaryManage', '日记管理', 1, '/beautyDiaryManage', '17');
INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`) VALUES ('51', 'BeautyDiaryTagInfo', '日记标签', 1, '/beautyDiaryTagInfo', '17');

-----------------------------------------------余建明 2021/09/23 END--------------------------------------------;

-----------------------------------------------余建明 2021/10/13 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `order_nature` TINYINT NOT NULL DEFAULT 0 AFTER `order_type`;

ALTER TABLE `amiyadb`.`tbl_module` 
ADD COLUMN `sort` INT NOT NULL DEFAULT 0 AFTER `module_category_id`;

ALTER TABLE `amiyadb`.`tbl_module_category` 
ADD COLUMN `sort` INT NOT NULL DEFAULT 0 AFTER `path`;

INSERT INTO `amiyadb`.`tbl_module` (`id`, `name`, `description`, `valid`, `path`, `module_category_id`, `sort`) VALUES (52, 'MenuManage', '菜单管理', 1, '/MenuManage', 12, 0);

-----------------------------------------------余建明 2021/10/13 END--------------------------------------------;



-----------------------------------------------余建明 2021/11/02 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `account_receivable` DECIMAL(10,2) NULL DEFAULT NULL AFTER `actual_payment`,--应收款

ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `final_consumption_hospital` VARCHAR(100) NULL DEFAULT NULL AFTER `appointment_hospital`;


update tbl_order_info set final_consumption_hospital=appointment_hospital, account_receivable=actual_payment

-----------------------------------------------余建明 2021/11/02 END--------------------------------------------;


-----------------------------------------------余建明 2021/11/08 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `added_by` INT NULL DEFAULT '0' AFTER `consume_type`;
-----------------------------------------------余建明 2021/11/08 END--------------------------------------------;






--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上

-----------------------------------------------余建明 2021/11/10 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_live_anchor` 
ADD COLUMN `host_account_name` VARCHAR(45) NULL AFTER `name`,
ADD COLUMN `content_plateform_id` VARCHAR(50) NULL AFTER `host_account_name`;



-----------------------------------------------余建明 2021/11/10 END--------------------------------------------;


-----------------------------------------------余建明 2021/11/11 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_plateform_order` 
CHANGE COLUMN `appointment_hospital_id` `appointment_hospital_id` INT NULL DEFAULT NULL ;

ALTER TABLE `amiyadb`.`tbl_content_plateform_order` 
ADD COLUMN `goods_id` VARCHAR(50) NULL AFTER `update_date`,
-----------------------------------------------余建明 2021/11/11 END--------------------------------------------;




-----------------------------------------------侯宝平 2021/11/11 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_plateform_order` 
MODIFY COLUMN `live_anchor_id` int(11) UNSIGNED NULL DEFAULT NULL AFTER `content_plateform_id`,
MODIFY COLUMN `appointment_hospital_id` int(11) UNSIGNED NULL DEFAULT NULL AFTER `appointment_date`,
ADD CONSTRAINT `fk_contentPlatformOrder_contentPlateformId_ContentPlateform_id` FOREIGN KEY (`content_plateform_id`) REFERENCES `amiyadb`.`tbl_content_platform` (`id`),
ADD CONSTRAINT `fk_contentPlatformOrder_liveAnchorId_liveAnchor_id` FOREIGN KEY (`live_anchor_id`) REFERENCES `amiyadb`.`tbl_live_anchor` (`id`),
ADD CONSTRAINT `fk_contentPlatformOrder_appointmentHospitalId_hospitalInfoId_id` FOREIGN KEY (`appointment_hospital_id`) REFERENCES `amiyadb`.`tbl_hospital_info` (`id`);

ALTER TABLE `amiyadb`.`tbl_content_plateform_order` 
ADD CONSTRAINT `fk_contentPlatformOrder_goodsId_amiyaGoodsDemand_id` FOREIGN KEY (`goods_id`) REFERENCES `amiyadb`.`tbl_amiya_goods_demand` (`id`);

-----------------------------------------------侯宝平 2021/11/11 END--------------------------------------------;


-----------------------------------------------侯宝平 2021/11/12 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_hospital_check_phone_record` DROP FOREIGN KEY `fk_hospitalCheckPhoneRecord_orderid_order_id`;

ALTER TABLE `amiyadb`.`tbl_hospital_check_phone_record` 
ADD COLUMN `order_platformn_type` tinyint(4) NOT NULL COMMENT '0=正常交易订单（淘宝等平台），1=内容平台订单' AFTER `hospital_employee_id`;
-----------------------------------------------侯宝平 2021/11/12 END--------------------------------------------;


-----------------------------------------------余建明 2021/12/1 BEGIN--------------------------------------------;
UPDATE `amiyadb`.`tbl_config` SET `config_json` = '{"FxJwtConfig":{"Key":"kljdsf982734jkldg!@#","ExpireInSeconds":7200,"RefreshTokenExpireInSeconds":14400},"FxOpenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxgatetest"},"FxOSSConfig":null,"FxRedisConfig":{"ConnectionString":"app.hsltm.com:6379,allowadmin=true,password=hsltm"},"FxSmsConfig":{"AliyunSmsList":[{"Name":"send_validate_code","AccessKeyId":"LTAIlyCdQbQnA96C","AccessSecret":"nXtBYoUzt3nw3v5DasAjNdLliuBB0h","RegionId":"cn_hangzhou","SignName":"杭州华山医院","TemplateCode":"SMS_126464576","Remark":"发送验证码"},{"Name":"order_buyerpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"阿美雅","TemplateCode":"SMS_224341042","Remark":"订单下单通知"},{"Name":"order_intergrationpay_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"阿美雅","TemplateCode":"SMS_224351049","Remark":"积分兑换通知"},{"Name":"order_gift_commit","AccessKeyId":"LTAI4FyjkURk6usCWjWucQ7o","AccessSecret":"T0GFcYOVS6FJyRj9HzzEtC3ljFdxjs","RegionId":"cn_hangzhou","SignName":"阿美雅","TemplateCode":"SMS_224346105","Remark":"礼品兑换通知"}]},"FxUniteWxAccessTokenConfig":{"Enable":true,"RequestBaseUrl":"https://app.hsltm.com/fxwxaccesstoken"},"WxPayConfig":null,"FxMessageCenterConfig":{"EnableMessageCenter":true,"EnableMessageQueue":true,"MQHostName":"app.hsltm.com","MQUserName":"admin","Port":5672,"MQPassword":"hsltm1007","MQQueueName":"fx_wxmp_message_queue","MessageCenterWebSocketUrl":null},"ChatInMinute":1440,"CallCenterConfig":{"CallRecordStoreAddress":"mongodb://192.168.11.72:27890","EnablevoiceCardCallable":false,"SupportOldCallBox":false,"SwitchSimCardInCallCount":5,"VoiceCardManagerAddress":"","PhoneEncryptKey":"test","EnablePhoneEncrypt":true,"HidePhoneNumber":true},"SyncOrderConfig":{"Jd":false,"Tmall":false,"WeiFenXiao":false},"NoticeConfig":{"EmailNoticeConfig":true}}' WHERE (`id` = '1');


ALTER TABLE `amiyadb`.`tbl_send_order_info` 
ADD COLUMN `purchase_single_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `send_date`,
ADD COLUMN `purchase_num` INT NOT NULL DEFAULT 0 AFTER `purchase_single_price`;


ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `live_anchor_id` INT NOT NULL DEFAULT '0' AFTER `already_write_off_amount`;


-----------------------------------------------余建明 2021/12/3 END--------------------------------------------;


-----------------------------------------------余建明 2021/12/13 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `nick_name` VARCHAR(45) NULL AFTER `added_by`,
ADD COLUMN `is_added_order` BIT(1) NOT NULL DEFAULT 0 AFTER `nick_name`,
ADD COLUMN `order_id` VARCHAR(50) NULL AFTER `is_added_order`,
ADD COLUMN `write_off_date` DATETIME NULL AFTER `order_id`,
ADD COLUMN `is_consultation_card` BIT(1) NOT NULL DEFAULT 0 AFTER `write_off_date`,
ADD COLUMN `buy_again_type` INT NOT NULL DEFAULT 0 AFTER `is_consultation_card`,
ADD COLUMN `is_self_living` BIT(1) NOT NULL DEFAULT 0 AFTER `buy_again_type`,
ADD COLUMN `buy_again_time` DATETIME NULL AFTER `is_self_living`,
ADD COLUMN `has_buyagain_evidence` BIT(1) NOT NULL DEFAULT 0 AFTER `buy_again_time`,
ADD COLUMN `buyagain_evidence_pic` VARCHAR(200) NULL AFTER `has_buyagain_evidence`,
ADD COLUMN `is_checktohospital` BIT(1) NOT NULL DEFAULT 0 AFTER `buyagain_evidence_pic`,
ADD COLUMN `checktohospital_pic` VARCHAR(200) NULL AFTER `is_checktohospital`,
ADD COLUMN `person_time` INT NOT NULL DEFAULT 1 AFTER `checktohospital_pic`,
ADD COLUMN `is_receive_additional_purchase` BIT(1) NOT NULL DEFAULT 0 AFTER `person_time`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
CHANGE COLUMN `nick_name` `nick_name` VARCHAR(45) NULL ,
CHANGE COLUMN `order_id` `order_id` VARCHAR(50) NULL ,
CHANGE COLUMN `buyagain_evidence_pic` `buyagain_evidence_pic` VARCHAR(200) NULL ,
CHANGE COLUMN `checktohospital_pic` `checktohospital_pic` VARCHAR(200) NULL ;

ALTER TABLE `amiyadb`.`tbl_content_platform_order_send` 
ADD COLUMN `hospital_remark` VARCHAR(200) NULL AFTER `remark`;


-----------------------------------------------余建明 2021/12/18 END--------------------------------------------;

-----------------------------------------------余建明 2021/12/24 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `un_deal_picture_url` VARCHAR(200) NULL AFTER `undeal_reason`;
-----------------------------------------------余建明 2021/12/24 END--------------------------------------------;


-----------------------------------------------余建明 2021/12/28 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `is_to_hospital` BIT(1) NOT NULL DEFAULT 0 AFTER `remark`;


-----------------------------------------------余建明 2021/12/28 END--------------------------------------------;



-----------------------------------------------余建明 2022/01/04 BEGIN--------------------------------------------;
--接新建tbl_liveanchor_monthly_target脚本之后
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `year` INT NOT NULL DEFAULT 0 AFTER `id`,
ADD COLUMN `month` INT NOT NULL AFTER `year`,
ADD COLUMN `create_date` DATETIME NOT NULL AFTER `month`;
-----------------------------------------------余建明 2022/01/04 END--------------------------------------------;





-----------------------------------------------余建明 2022/01/10 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `record_date` DATETIME NOT NULL AFTER `performance_num`;

-----------------------------------------------余建明 2022/01/10 END--------------------------------------------;


-----------------------------------------------余建明 2022/01/12 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `due_time` DATETIME NULL AFTER `business_hours`,
ADD COLUMN `contract_url` VARCHAR(300) NULL AFTER `due_time`;


ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `check_buy_again_price` DECIMAL(10,2) NULL AFTER `is_receive_additional_purchase`,
ADD COLUMN `check_settle_price` DECIMAL(10,2) NULL AFTER `check_buy_again_price`,
ADD COLUMN `check_date` DATETIME NULL AFTER `check_settle_price`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `check_state` INT NOT NULL DEFAULT 0 AFTER `check_date`;


ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `check_by` INT NULL AFTER `check_state`;



-----------------------------------------------余建明 2022/01/13 END--------------------------------------------;


-----------------------------------------------余建明 2022/01/14 BEGIN--------------------------------------------;

update amiyadb.tbl_customer_hospital_consume set check_by =0

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
CHANGE COLUMN `check_by` `check_by` INT NOT NULL DEFAULT 0 ;


---1.14  15：12
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `remark` VARCHAR(300) NULL AFTER `check_by`;
-----------------------------------------------余建明 2022/01/14 END--------------------------------------------;


-----------------------------------------------余建明 2022/01/22 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `deal_date` DATETIME NULL AFTER `is_to_hospital`;

ALTER TABLE `amiyadb`.`tbl_hospital_partake_item` 
ADD COLUMN `is_agree_living_price` BIT(1) NOT NULL DEFAULT 0 AFTER `item_id`,
ADD COLUMN `hospital_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `is_agree_living_price`;

-----------------------------------------------余建明 2022/01/22 END--------------------------------------------;


-----------------------------------------------余建明 2022/02/16 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `clues_target` INT NOT NULL DEFAULT 0 AFTER `flow_investment_complete_rate`,
ADD COLUMN `cumulative_clues` INT NOT NULL DEFAULT 0 AFTER `clues_target`,
ADD COLUMN `clues_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_clues`,
ADD COLUMN `add_fans_target` INT NOT NULL DEFAULT 0 AFTER `clues_complete_rate`,
ADD COLUMN `cumulative_add_fans` INT NOT NULL DEFAULT 0 AFTER `add_fans_target`,
ADD COLUMN `add_fans_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_add_fans`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `clue_num` INT(11) NOT NULL DEFAULT 0 AFTER `flow_investment_num`,
ADD COLUMN `add_fans_num` INT(11) NOT NULL DEFAULT 0 AFTER `clue_num`;

-----------------------------------------------余建明 2022/02/16 END--------------------------------------------;

-----------------------------------------------余建明 2022/03/02 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `check_state` INT NOT NULL DEFAULT 0.00 AFTER `deal_date`,
ADD COLUMN `check_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_state`,
ADD COLUMN `settle_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_price`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `check_by` INT NOT NULL DEFAULT 0 AFTER `settle_price`;

-----------------------------------------------余建明 2022/03/02 END--------------------------------------------;

-----------------------------------------------余建明 2022/03/10 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `channel` INT NOT NULL DEFAULT 0 AFTER `consume_type`;

ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `belong_emp_id` INT NOT NULL DEFAULT 0 AFTER `live_anchor_id`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `belong_emp_id` INT NULL DEFAULT 0 AFTER `check_by`;


-----------------------------------------------余建明 2022/03/10 END--------------------------------------------;


-----------------------------------------------余建明 2022/03/14 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `check_remark` VARCHAR(300) NULL AFTER `remark`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `check_remark` VARCHAR(300) NULL AFTER `belong_emp_id`;


-----------------------------------------------余建明 2022/03/14 END--------------------------------------------;

-----------------------------------------------余建明 2022/03/26 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `livingroomflow_investment_target` INT NOT NULL DEFAULT 0 AFTER `flow_investment_complete_rate`,
ADD COLUMN `cumulative_livingroomflow_investment` INT NOT NULL DEFAULT 0 AFTER `livingroomflow_investment_target`,
ADD COLUMN `livingroomflow_investment_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_livingroomflow_investment`,
ADD COLUMN `consultation_target` INT NOT NULL DEFAULT 0 AFTER `add_wechat_complete_rate`,
ADD COLUMN `cumulative_consultation` INT NOT NULL DEFAULT 0 AFTER `consultation_target`,
ADD COLUMN `consultation_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_consultation`,
ADD COLUMN `cargosettlementcommission_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `deal_rate`,
ADD COLUMN `cumulation_cargosettlementcommission` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cargosettlementcommission_target`,
ADD COLUMN `cargosettlementcommission_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulation_cargosettlementcommission`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `livingroomflow_investment_num` INT NOT NULL DEFAULT 0 AFTER `flow_investment_num`,
ADD COLUMN `consultation_num` INT NOT NULL DEFAULT 0 AFTER `add_wechat_num`,
ADD COLUMN `cargosettlementcommission` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `deal_num`;


-----------------------------------------------余建明 2022/03/26 END--------------------------------------------;

-----------------------------------------------余建明 2022/04/02 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_item_info` 
ADD COLUMN `hospital_department_id` VARCHAR(45) NULL AFTER `name`,
-----------------------------------------------余建明 2022/04/02 END--------------------------------------------;

-----------------------------------------------余建明 2022/04/06 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `new_visit_nun` INT NOT NULL DEFAULT 0 AFTER `send_order_num`,
ADD COLUMN `subsequent_visit_num` INT NOT NULL DEFAULT 0 AFTER `new_visit_nun`,
ADD COLUMN `old_customer_visit_num` INT NOT NULL DEFAULT 0 AFTER `subsequent_visit_num`,
ADD COLUMN `new_deal_num` INT NOT NULL DEFAULT 0 AFTER `visit_num`,
ADD COLUMN `subsequent_deal_num` INT NOT NULL DEFAULT 0 AFTER `new_deal_num`,
ADD COLUMN `new_performance_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cargosettlementcommission`,
ADD COLUMN `subsequent_performance_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `new_performance_num`,
ADD COLUMN `old_customer_performance_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `subsequent_performance_num`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `live_anchor_id` INT NOT NULL DEFAULT 0 AFTER `check_remark`;


-----------------------------------------------余建明 2022/04/06 END--------------------------------------------;
-----------------------------------------------余建明 2022/04/11 BEGIN--------------------------------------------;
  ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `check_date` DATETIME NULL AFTER `check_remark`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `hospital_department_id` VARCHAR(50) NULL AFTER `goods_id`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `hospital_create_time` DATETIME NULL AFTER `name`,
ADD COLUMN `industry_honors` VARCHAR(200) NULL AFTER `contract_url`,
ADD COLUMN `profile_rank` VARCHAR(200) NULL AFTER `industry_honors`;

ALTER TABLE `amiyadb`.`tbl_doctor` 
ADD COLUMN `project_picture` VARCHAR(200) NULL AFTER `hospital_id`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `description` VARCHAR(2000) NULL AFTER `profile_rank`;

ALTER TABLE `amiyadb`.`tbl_doctor` 
ADD COLUMN `department_id` VARCHAR(50) NULL AFTER `name`;

ALTER TABLE `amiyadb`.`tbl_doctor` 
ADD COLUMN `is_main` INT NOT NULL DEFAULT 0 AFTER `project_picture`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `area` DECIMAL(10,2) NULL AFTER `description`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `description_picture` VARCHAR(300) NULL AFTER `area`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
CHANGE COLUMN `area` `area` DECIMAL(10,2) NULL DEFAULT 0.00 ;



-----------------------------------------------余建明 2022/04/11 END--------------------------------------------;


-----------------------------------------------余建明 2022/04/16 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `check_state` INT NULL DEFAULT 0 AFTER `description_picture`,
ADD COLUMN `check_by` INT NULL AFTER `check_state`,
ADD COLUMN `check_date` DATETIME NULL AFTER `check_by`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `check_remark` VARCHAR(300) NULL AFTER `check_date`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `submit_state` INT NULL DEFAULT 0 AFTER `check_remark`;


-----------------------------------------------余建明 2022/04/16 END--------------------------------------------;



-----------------------------------------------余建明 2022/04/22 BEGIN--------------------------------------------;
--内容平台订单来源
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `order_source` INT not  NULL default 0 AFTER `appointment_hospital_id`;

update amiyadb.tbl_content_platform_order set order_source=2;

--添加未派单原因，接诊咨询
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `unsend_reason` VARCHAR(300) NULL AFTER `check_date`,
ADD COLUMN `accepts_consulting` VARCHAR(45) NULL AFTER `unsend_reason`;


-----------------------------------------------余建明 2022/04/22 END--------------------------------------------;

-----------------------------------------------余建明 2022/04/24 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_wait_track_customer` 
ADD COLUMN `track_plan` VARCHAR(500) NULL AFTER `plan_track_employee_id`;
ALTER TABLE `amiyadb`.`tbl_track_record` 
ADD COLUMN `track_plan` VARCHAR(500) NULL AFTER `call_record_id`;
-----------------------------------------------余建明 2022/04/24 END--------------------------------------------;

-----------------------------------------------余建明 2022/05/05 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `to_hospital_date` DATETIME NULL AFTER `accepts_consulting`,
ADD COLUMN `last_deal_hospital_id` INT NULL AFTER `to_hospital_date`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `to_hospital_date` DATETIME NULL AFTER `price`,
ADD COLUMN `last_deal_hospital_id` INT NULL AFTER `to_hospital_date`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `consultation_emp_id` INT NULL AFTER `appointment_hospital_id`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `consume_id` VARCHAR(50) NULL AFTER `id`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `is_return_back_price` BIT(1) NOT NULL AFTER `last_deal_hospital_id`,
ADD COLUMN `return_back_price` DECIMAL(12,2) NULL AFTER `is_return_back_price`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `is_return_back_price` BIT(1) NOT NULL AFTER `live_anchor_id`,
ADD COLUMN `return_back_price` DECIMAL(12,2) NULL AFTER `is_return_back_price`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `return_back_date` DATETIME NULL AFTER `return_back_price`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `return_back_date` DATETIME NULL AFTER `return_back_price`;
-----------------------------------------------余建明 2022/05/05 END--------------------------------------------;

-----------------------------------------------余建明 2022/05/16 BEGIN--------------------------------------------;
--下单平台财务审核功能
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `check_state` INT NOT NULL DEFAULT 0 AFTER `belong_emp_id`,
ADD COLUMN `check_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_state`,
ADD COLUMN `settle_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_price`,
ADD COLUMN `check_by` INT NOT NULL DEFAULT 0 AFTER `settle_price`,
ADD COLUMN `check_remark` VARCHAR(300) NULL AFTER `check_by`,
ADD COLUMN `check_date` DATETIME NULL AFTER `check_remark`,
ADD COLUMN `is_return_back_price` BIT(1) NOT NULL AFTER `check_date`,
ADD COLUMN `return_back_price` DECIMAL(12,2) NULL AFTER `is_return_back_price`,
ADD COLUMN `return_back_date` DATETIME NULL AFTER `return_back_price`;

ALTER TABLE `amiyadb`.`tbl_order_info` 
CHANGE COLUMN `check_by` `check_by` INT NULL ;
ALTER TABLE `amiyadb`.`tbl_order_info` 
CHANGE COLUMN `check_price` `check_price` DECIMAL(10,2) NULL DEFAULT '0.00' ,
CHANGE COLUMN `settle_price` `settle_price` DECIMAL(10,2) NULL DEFAULT '0.00' ;



ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `old_customer_deal_num` INT(11) NOT NULL DEFAULT 0 AFTER `subsequent_deal_num`,
ADD COLUMN `new_customer_performance_count_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `subsequent_performance_num`;


--主播IP日运营报表新增数据维度
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `consultation_card_consumed` INT NOT NULL DEFAULT 0 AFTER `consultation_num`,
ADD COLUMN `activate_historical_consultation` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed`,
ADD COLUMN `mini_van_refund` INT NOT NULL DEFAULT 0 AFTER `performance_num`,
ADD COLUMN `mini_van_bad_reviews` INT NOT NULL DEFAULT 0 AFTER `mini_van_refund`;


--主播IP月运营报表新增数据维度
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `consultation_card_consumed_target` INT NOT NULL DEFAULT 0 AFTER `consultation_complete_rate`,
ADD COLUMN `cumulative_consultation_card_consumed` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed_target`,
ADD COLUMN `consultation_card_consumed_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.0 AFTER `cumulative_consultation_card_consumed`,
ADD COLUMN `activate_historical_consultation_target` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed_complete_rate`,
ADD COLUMN `cumulative_activate_historical_consultation` INT NOT NULL DEFAULT 0 AFTER `activate_historical_consultation_target`,
ADD COLUMN `activate_historical_consultation_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_activate_historical_consultation`,
ADD COLUMN `minivan_refund_target` INT NOT NULL DEFAULT 0 AFTER `performance_complete_rate`,
ADD COLUMN `cumulative_minivan_refund` INT NOT NULL DEFAULT 0 AFTER `minivan_refund_target`,
ADD COLUMN `minivan_refund_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_minivan_refund`,
ADD COLUMN `mini_van_bad_reviews_target` INT NOT NULL DEFAULT 0 AFTER `minivan_refund_complete_rate`,
ADD COLUMN `cumulative_mini_van_bad_reviews` INT NOT NULL DEFAULT 0 AFTER `mini_van_bad_reviews_target`,
ADD COLUMN `mini_van_bad_reviews_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_mini_van_bad_reviews`;

-----------------------------------------------余建明 2022/05/19 END--------------------------------------------;


-----------------------------------------------余建明 2022/05/30 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `other_content_platform_order_id` VARCHAR(50) NULL AFTER `content_plateform_id`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `other_content_platform_order_id` VARCHAR(50) NULL AFTER `order_id`;

-----------------------------------------------余建明 2022/05/30 END--------------------------------------------;

-----------------------------------------------余建明 2022/06/01 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `is_confirm_order` BIT(1) NOT NULL AFTER `return_back_date`;


update amiyadb.tbl_content_platform_order set order_status='6' where order_status='5';
update amiyadb.tbl_content_platform_order set order_status='5' where order_status='4';
update amiyadb.tbl_content_platform_order set order_status='4' where order_status='3';
-----------------------------------------------余建明 2022/06/01 END--------------------------------------------;


-----------------------------------------------余建明 2022/06/14 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_bind_customer_service` 
ADD COLUMN `first_consumption_date` DATETIME NULL AFTER `create_by`,
ADD COLUMN `new_consumption_date` DATETIME NULL AFTER `first_consumption_date`,
ADD COLUMN `new_consumption_content_platform` INT NULL AFTER `new_consumption_date`,
ADD COLUMN `new_content_platform` VARCHAR(45) NULL AFTER `new_consumption_content_platform`,
ADD COLUMN `all_price` DECIMAL(12,2) NULL AFTER `new_content_platform`,
ADD COLUMN `all_order_count` INT NULL AFTER `all_price`;

ALTER TABLE `amiyadb`.`tbl_bind_customer_service` 
ADD COLUMN `first_project_demand` VARCHAR(200) NULL AFTER `create_by`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `living_tracking_employee_id` INT NOT NULL DEFAULT 0 AFTER `operation_employee_id`;

-----------------------------------------------余建明 2022/06/14 END--------------------------------------------;





-----------------------------------------------余建明 2022/06/24 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_amiya_warehouse` 
ADD INDEX `warehouse_info_idx` (`goods_source_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse` 
ADD CONSTRAINT `warehouse_info`
  FOREIGN KEY (`goods_source_id`)
  REFERENCES `amiyadb`.`tbl_amiya_warehouse_name_manage` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


  ALTER TABLE `amiyadb`.`tbl_inventory_list` 
CHANGE COLUMN `create_by` `create_by` INT UNSIGNED NOT NULL ,
ADD INDEX `fk_omvemtory_by_idx` (`create_by` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_inventory_list` 
ADD CONSTRAINT `fk_omvemtory_by`
  FOREIGN KEY (`create_by`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  ALTER TABLE `amiyadb`.`tbl_inventory_list` 
ADD COLUMN `inventory_state` INT NOT NULL DEFAULT 0 AFTER `warehouse_id`,
ADD COLUMN `inventory_num` INT NOT NULL AFTER `inventory_state`,
ADD COLUMN `inventory_price` DECIMAL(12,2) NOT NULL AFTER `inventory_num`,
ADD COLUMN `remark` VARCHAR(500) NULL AFTER `create_date`;

ALTER TABLE `amiyadb`.`tbl_amiya_in_warehouse` 
ADD CONSTRAINT `fk_in_warehouse_info`
  FOREIGN KEY (`warehouse_id`)
  REFERENCES `amiyadb`.`tbl_amiya_warehouse` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  ALTER TABLE `amiyadb`.`tbl_amiya_in_warehouse` 
CHANGE COLUMN `create_by` `create_by` INT UNSIGNED NOT NULL ,
ADD INDEX `fk_in_warehouse_empid_idx` (`create_by` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_amiya_in_warehouse` 
ADD CONSTRAINT `fk_in_warehouse_empid`
  FOREIGN KEY (`create_by`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  ALTER TABLE `amiyadb`.`tbl_amiya_out_warehouse` 
CHANGE COLUMN `create_by` `create_by` INT UNSIGNED NOT NULL ,
ADD INDEX `fk_out_warehouse_empid_idx` (`create_by` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_amiya_out_warehouse` 
ADD CONSTRAINT `fk_out_warehouse_empid`
  FOREIGN KEY (`create_by`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


  ALTER TABLE `amiyadb`.`tbl_amiya_out_warehouse` 
ADD COLUMN `use_employee_id` INT UNSIGNED NOT NULL AFTER `create_by`,
ADD COLUMN `department_id` INT UNSIGNED NOT NULL AFTER `use_employee_id`,
ADD INDEX `fk_use_emp_info_idx` (`use_employee_id` ASC) VISIBLE,
ADD INDEX `fk_use_department_info_idx` (`department_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_amiya_out_warehouse` 
ADD CONSTRAINT `fk_use_emp_info`
  FOREIGN KEY (`use_employee_id`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_use_department_info`
  FOREIGN KEY (`department_id`)
  REFERENCES `amiyadb`.`tbl_amiya_department` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;



-----------------------------------------------余建明 2022/06/24 END--------------------------------------------;





-----------------------------------------------王健 2022/07/04 BEGIN--------------------------------------------;


ALTER TABLE `amiyadb`.`tbl_homepage_carousel_image` 
ADD COLUMN `link_url` VARCHAR(200)  NOT NULL AFTER `create_date`;




-----------------------------------------------王健 2022/07/04 END--------------------------------------------;

-----------------------------------------------余建明 2022/07/05 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `consultation_num2` INT NOT NULL DEFAULT 0 AFTER `consultation_num`,
ADD COLUMN `consultation_card_consumed2` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `consultation_target2` INT NOT NULL DEFAULT 0 AFTER `consultation_complete_rate`,
ADD COLUMN `cumulative_consultation2` INT NOT NULL DEFAULT 0 AFTER `consultation_target2`,
ADD COLUMN `consultation_complete_rate2` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_consultation2`,
ADD COLUMN `consultation_card_consumed_target2` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed_complete_rate`,
ADD COLUMN `cumulative_consultation_card_consumed2` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed_target2`,
ADD COLUMN `consultation_card_consumed_complete_rate2` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_consultation_card_consumed2`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `deal_date` DATETIME NULL AFTER `last_deal_hospital_id`,
ADD COLUMN `other_order_id` VARCHAR(50) NULL AFTER `deal_date`;



--主播IP日运营报表关联关系
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD INDEX `fk_live_anchor_monthly_target_info_idx` (`liveanchor_monthly_target_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD CONSTRAINT `fk_live_anchor_monthly_target_info`
  FOREIGN KEY (`liveanchor_monthly_target_id`)
  REFERENCES `amiyadb`.`tbl_liveanchor_monthly_target` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;



  --主播月度报表关联关系
 ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
CHANGE COLUMN `live_anchor_id` `live_anchor_id` INT UNSIGNED NOT NULL DEFAULT '0' ,
ADD INDEX `fk_live_anchor_info_idx` (`live_anchor_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD CONSTRAINT `fk_live_anchor_info`
  FOREIGN KEY (`live_anchor_id`)
  REFERENCES `amiyadb`.`tbl_live_anchor` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
-----------------------------------------------余建明 2022/07/05 END--------------------------------------------;




-----------------------------------------------余建明 2022/07/12 BEGIN--------------------------------------------;


--内容平台成交情况
  ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `to_hospital_type` INT NOT NULL DEFAULT 0 AFTER `is_to_hospital`;


--内容平台订单
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `to_hospital_type` INT NOT NULL DEFAULT 0 AFTER `is_to_hospital`;

----------------------------------------------------------------------------------------------------------------------------------------------------以上已发布至线上


--购物车
ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
ADD COLUMN `city_id` INT UNSIGNED NOT NULL AFTER `update_date`,
ADD COLUMN `hosiptal_id` INT UNSIGNED NOT NULL AFTER `city_id`,
ADD INDEX `fk_city_info_idx` (`city_id` ASC) VISIBLE,
ADD INDEX `fk_hospital_info_idx` (`hosiptal_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
ADD CONSTRAINT `fk_city_info`
  FOREIGN KEY (`city_id`)
  REFERENCES `amiyadb`.`tbl_cooperative_hospital_city` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_hospital_info`
  FOREIGN KEY (`hosiptal_id`)
  REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  --购物车
  ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
DROP FOREIGN KEY `fk_city_info`,
DROP FOREIGN KEY `fk_hospital_info`;
ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
CHANGE COLUMN `city_id` `city_id` INT UNSIGNED NULL ,
CHANGE COLUMN `hosiptal_id` `hosiptal_id` INT UNSIGNED NULL ;
ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
ADD CONSTRAINT `fk_city_info`
  FOREIGN KEY (`city_id`)
  REFERENCES `amiyadb`.`tbl_cooperative_hospital_city` (`id`),
ADD CONSTRAINT `fk_hospital_info`
  FOREIGN KEY (`hosiptal_id`)
  REFERENCES `amiyadb`.`tbl_hospital_info` (`id`);

  
-----------------------------------------------余建明 2022/07/12 END--------------------------------------------;




































-----------------------------------------------余建明 2022/05/05 BEGIN--------------------------------------------;
--商学院板块
ALTER TABLE `amiyadb`.`tbl_business_college_monthly_target` 
ADD COLUMN `create_date` DATETIME NOT NULL AFTER `performance_complete_rate`,
ADD COLUMN `created_by` INT NOT NULL AFTER `create_date`;
-----------------------------------------------余建明 2022/05/05 END--------------------------------------------;


















--财务报表模块
ALTER TABLE `amiyadb`.`tbl_hospital_financial_statement` 
ADD COLUMN `hospital_submit_settle_commission` DECIMAL(12,2) NULL AFTER `hospital_submit_price`,
ADD COLUMN `flag_state` INT NOT NULL DEFAULT 0 AFTER `hospital_submit_settle_commission`;