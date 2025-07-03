using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlCenterApp.Models
{
    [Table("A3_STD_SALEUNIT", Schema = "dbo")]
    public class SaleUnit
    {
        [Key]
        [Column("SALEUNIT_ID")]
        public Guid SaleUnitId { get; set; }

        [Column("INSERT_TIME")]
        public DateTime? InsertTime { get; set; }

        [Required]
        [Column("SALEUNIT_CODE")]
        public string SaleUnitCode { get; set; } = string.Empty;

        [Column("SALEUNIT_NAME")]
        public string? SaleUnitName { get; set; }

        [Column("NOTE")]
        public string? Note { get; set; }

        [Required]
        [Column("PL_REVIEW_CFG")]
        public int PlReviewCfg { get; set; }

        [Column("SALEUNIT_TYPE_ID")]
        public Guid? SaleUnitTypeId { get; set; }

        [Column("SALEUNIT_GROUP_ID")]
        public Guid? SaleUnitGroupId { get; set; }

        [Column("SALEUNIT_REGION_ID")]
        public Guid? SaleUnitRegionId { get; set; }
    }
}
