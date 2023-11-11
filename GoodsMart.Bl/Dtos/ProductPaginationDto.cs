using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.Bl;

public class ProductPaginationDto
{
    public IEnumerable<ProductReadDto> products { get; set; } = new List<ProductReadDto>();
    public int TotalCount { get; set; }
}
