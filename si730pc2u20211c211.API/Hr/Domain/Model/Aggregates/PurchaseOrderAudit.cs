using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;

public partial class JoinRequest : IEntityWithCreatedUpdatedDate
{
    [Column("createdAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}