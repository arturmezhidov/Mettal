using System.Collections.Generic;
using Mettal.Models.Business;
using Mettal.Models.Entities;

namespace Mettal.Models.ViewModels
{
    public class PositionsView
    {
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public Table Table { get; set; }
        public List<PositionMember> Positions { get; set; }
        public int RowsCount { get; set; }
    }
}