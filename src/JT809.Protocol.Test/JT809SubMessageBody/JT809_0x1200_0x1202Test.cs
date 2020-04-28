﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using JT809.Protocol.MessageBody;
using JT809.Protocol.Exceptions;
using JT809.Protocol.SubMessageBody;
using JT809.Protocol.Internal;
using JT809.Protocol.Enums;

namespace JT809.Protocol.Test.JT809SubMessageBody
{
    public class JT809_0x1200_0x1202Test
    {
        private JT809Serializer JT809Serializer = new JT809Serializer();

        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });

        [Fact]
        public void Test1()
        {
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202.VehiclePosition = new Metadata.JT809VehiclePositionProperties();
            jT809_0X1200_0X1202.VehiclePosition.Day = 19;
            jT809_0X1200_0X1202.VehiclePosition.Month = 7;
            jT809_0X1200_0X1202.VehiclePosition.Year = 2012;
            jT809_0X1200_0X1202.VehiclePosition.Hour = 15;
            jT809_0X1200_0X1202.VehiclePosition.Minute = 15;
            jT809_0X1200_0X1202.VehiclePosition.Second = 15;
            jT809_0X1200_0X1202.VehiclePosition.Lon = 133123456;
            jT809_0X1200_0X1202.VehiclePosition.Lat = 24123456;
            jT809_0X1200_0X1202.VehiclePosition.Vec1 = 50;
            jT809_0X1200_0X1202.VehiclePosition.Vec2 = 51;
            jT809_0X1200_0X1202.VehiclePosition.Vec3 = 150;
            jT809_0X1200_0X1202.VehiclePosition.Direction = 45;
            jT809_0X1200_0X1202.VehiclePosition.Altitude = 45;
            jT809_0X1200_0X1202.VehiclePosition.State = 3;
            jT809_0X1200_0X1202.VehiclePosition.Alarm = 257;
            var hex = JT809Serializer.Serialize(jT809_0X1200_0X1202).ToHexString();
            //"00 13 07 07 DC 0F 0F 0F 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01"
            Assert.Equal("00130707DC0F0F0F07EF4D80017018400032003300000096002D002D0000000300000101", hex);
        }

        [Fact]
        public void Test2()
        {
            var bytes = "00 13 07 07 DC 0F 0F 0F 07 EF 4D 80 01 70 18 40 00 32 00 33 00 00 00 96 00 2D 00 2D 00 00 00 03 00 00 01 01".ToHexBytes();
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = JT809Serializer.Deserialize<JT809_0x1200_0x1202>(bytes);
            Assert.Equal(19, jT809_0X1200_0X1202.VehiclePosition.Day);
            Assert.Equal(7, jT809_0X1200_0X1202.VehiclePosition.Month);
            Assert.Equal(2012, jT809_0X1200_0X1202.VehiclePosition.Year);
            Assert.Equal(15, jT809_0X1200_0X1202.VehiclePosition.Hour);
            Assert.Equal(15, jT809_0X1200_0X1202.VehiclePosition.Minute);
            Assert.Equal(15, jT809_0X1200_0X1202.VehiclePosition.Second);
            Assert.Equal((uint)133123456, jT809_0X1200_0X1202.VehiclePosition.Lon);
            Assert.Equal((uint)24123456, jT809_0X1200_0X1202.VehiclePosition.Lat);
            Assert.Equal(50, jT809_0X1200_0X1202.VehiclePosition.Vec1);
            Assert.Equal(51, jT809_0X1200_0X1202.VehiclePosition.Vec2);
            Assert.Equal((ushort)45, jT809_0X1200_0X1202.VehiclePosition.Direction);
            Assert.Equal((ushort)45, jT809_0X1200_0X1202.VehiclePosition.Altitude);
            Assert.Equal((uint)3, jT809_0X1200_0X1202.VehiclePosition.State);
            Assert.Equal((uint)257, jT809_0X1200_0X1202.VehiclePosition.Alarm);
        }

        [Fact]
        public void Test_2019_1()
        {
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = new JT809_0x1200_0x1202();
            jT809_0X1200_0X1202.GNSSData = new Metadata.JT809VehiclePositionProperties_2019();
            jT809_0X1200_0X1202.GNSSData.Encrypt = JT809_VehiclePositionEncrypt.已加密;
            //jT809_0X1200_0X1202.GNSSData.GnssData = new byte[20];
            jT809_0X1200_0X1202.GNSSData.PlatformId1 = "11111111111";
            jT809_0X1200_0X1202.GNSSData.Alarm1 = 1;
            jT809_0X1200_0X1202.GNSSData.PlatformId2 = "22222222222";
            jT809_0X1200_0X1202.GNSSData.Alarm2 = 2;
            jT809_0X1200_0X1202.GNSSData.PlatformId3 = "33333333333";
            jT809_0X1200_0X1202.GNSSData.Alarm3 = 3;
            var hex = JT809_2019_Serializer.Serialize(jT809_0X1200_0X1202).ToHexString();
            Assert.Equal("0100000000313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003", hex);

        }

        [Fact]
        public void Test_2019_2()
        {
            var bytes = "0100000000313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003".ToHexBytes();
            JT809_0x1200_0x1202 jT809_0X1200_0X1202 = JT809_2019_Serializer.Deserialize<JT809_0x1200_0x1202>(bytes);
            Assert.Equal( JT809_VehiclePositionEncrypt.已加密, jT809_0X1200_0X1202.GNSSData.Encrypt);
            Assert.Equal("11111111111", jT809_0X1200_0X1202.GNSSData.PlatformId1);
            Assert.Equal(1u, jT809_0X1200_0X1202.GNSSData.Alarm1);
            Assert.Equal("22222222222", jT809_0X1200_0X1202.GNSSData.PlatformId2);
            Assert.Equal(2u, jT809_0X1200_0X1202.GNSSData.Alarm2);
            Assert.Equal("33333333333", jT809_0X1200_0X1202.GNSSData.PlatformId3);
            Assert.Equal(3u, jT809_0X1200_0X1202.GNSSData.Alarm3);
        }

    }
}
