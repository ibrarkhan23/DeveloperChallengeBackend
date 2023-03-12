using DeveloperChallenge.Models.Dtos.OutputDtos;
using DeveloperChallenge.Models.Shared;
using DeveloperChallenge.Services.Interfaces;
using LP.Shared.Configuration;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperChallenge.Services.Services
{
    public class ShipperService : IShipperService
    {
        private static readonly string ConnectionString = DbConfigFactory.GetDbConfig().GetConnection("MyConn");
        public Tuple<int, string, object> GetShippers()
        {
            var sqlHelper = new SqlHelper(ConnectionString);

            var query = $"select shipper_id as shipperId,shipper_name as shipperName from SHIPPER";

            var dataTable = sqlHelper.GetDataTable(query, CommandType.Text);

            var jsonResult = JsonConvert.SerializeObject(dataTable);

            var json = JsonConvert.DeserializeObject<List<ShipperNameOutPutDto>>(jsonResult);

            return new Tuple<int, string, object>((int)HttpStatusCode.OK, "ShipperNames fetched successfully", json);
        }
        public Tuple<int, string, object> GetShipperDetailById(int id)
        {
            var sqlHelper = new SqlHelper(ConnectionString);

            var shipperParams = new List<SqlParameter>
                {
                    new SqlParameter("@shipperId", id)
                };

            var dataTable = sqlHelper.GetDataTable("Shipper_Shipment_Details", CommandType.StoredProcedure, shipperParams.ToArray());

            var jsonResult = JsonConvert.SerializeObject(dataTable);

            var json = JsonConvert.DeserializeObject<List<ShipperDetailOutPutDto>>(jsonResult);


            return new Tuple<int, string, object>((int)HttpStatusCode.OK, "Shippers details fetched successfully", json);
        }

    }

}



