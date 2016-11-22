using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mettal.Models.Business;
using Mettal.Models.Entities;

namespace Mettal.Helpers
{
    public static class PositionHelper
    {
        public static IEnumerable<ProductModel> GetProductModels(IEnumerable<Product> items)
        {
            var result = items.Select(model => new ProductModel
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Diameter = model.Diameter,
                Height = model.Height,
                Thickness = model.Thickness,
                Width = model.Width,
                Sechenie = model.Sechenie,
                Weight = model.Weight,
                WeightOne = model.WeightOne,
                WeightOneKg = model.WeightOneKg,
                Stenka = model.Stenka,
                Surface = model.Surface,
                Length = model.Length,
                Info1 = model.Info1,
                Info2 = model.Info2,
                Info3 = model.Info3,
                Country = model.Country.Name,
                Gost = model.Gost.Name,
                Mark = model.Mark.Name,
                Target = model.Target.Name
            });
            return result;
        }

        public static IEnumerable<PositionMember> GetPositionMembers(IEnumerable<Product> items, Table table)
        {
            List<ProductModel> models = GetProductModels(items).ToList();

            PropertyInfo[] schemas = typeof(Table).GetProperties();
            PropertyInfo[] properties = typeof(ProductModel).GetProperties();
            List<PositionMember> result = new List<PositionMember>();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "Id")
                {
                    PositionMember memberId = new PositionMember { OrderNumber = 0, Title = "Id" };
                    foreach (ProductModel model in models)
                    {
                        memberId.Values.Add(property.GetValue(model));
                    }
                    result.Add(memberId);
                    continue;
                }

                bool isShow = (bool)schemas.First(p => p.Name == (property.Name + "IsShow")).GetValue(table);

                if (!isShow)
                {
                    continue;
                }

                PositionMember member = new PositionMember();

                member.Title = schemas.First(p => p.Name == (property.Name + "Title")).GetValue(table).ToString();
                member.OrderNumber = (int)schemas.First(p => p.Name == (property.Name + "OrderNumber")).GetValue(table);

                foreach (ProductModel model in models)
                {
                    member.Values.Add(property.GetValue(model));
                }

                result.Add(member);
            }

            return result;
        }
    }
}