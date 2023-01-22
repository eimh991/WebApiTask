﻿using System;
using System.Data;
using WebApiTask.Model;

namespace WebApiTask.Services
{
    public class SmsServiseGenerator : ISmsService
    {
        public Message CreateMessage(string name, string text, string phoneNumber, Statuses status)
        {
            Message message = new Message() {SendersName=name,Created= DateTime.Now,MessageText=text,PhoneNumber = phoneNumber, Status=status };

            return message;

        }
    }
}
