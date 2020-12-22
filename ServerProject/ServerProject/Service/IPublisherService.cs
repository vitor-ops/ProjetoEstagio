using ClientProject.Models;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.Service
{
    public interface IPublisherService
    {

        Task Send(DataTransfer data);

    }
}
