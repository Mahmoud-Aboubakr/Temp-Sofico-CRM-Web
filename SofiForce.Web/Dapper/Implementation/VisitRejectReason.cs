using Dapper;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using SofiForce.Models.Models.EntityModels;
using SofiForce.Models.StatisticalModels;
using SofiForce.Web.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Implementation;


public class VisitRejectReason : IVisitRejectReason
{
    private readonly DapperContext _dapperContext;
    public VisitRejectReason(DapperContext context)
    {
        _dapperContext = context;
    }

    public async Task<IEnumerable<VisitRejectReasonModel>> GetAllVisitRejectReasonASync()
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var sql = @"SELECT * FROM VisitRejectReason";
            var result = await connection.QueryAsync<VisitRejectReasonModel>(sql);
            return result;
        }
    }


    public async Task<VisitRejectReasonModel> GetVisitRejectReasonByIdAsync(int id)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var param = new
            {
                @VisitRejectReasonId = id,
            };
            var sql = @"SELECT * FROM VisitRejectReason WHERE VisitRejectReasonId = @VisitRejectReasonId";

            var entity = await connection.QueryFirstOrDefaultAsync<VisitRejectReasonModel>(sql, param);
            return entity;
        }
    }

    public async Task<int> CreateVisitRejectReasonAsync(VisitRejectReasonModel entity)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var sql = @"INSERT INTO VisitRejectReason 
                    (VisitRejectReasonCode, VisitRejectReasonNameEn, VisitRejectReasonNameAr, IsActive, IsDeleted, 
                    CanEdit, CanDelete, DisplayOrder, Color, Icon, CBy, CDate, EBy, EDate)
                    VALUES 
                    (@VisitRejectReasonCode, @VisitRejectReasonNameEn, @VisitRejectReasonNameAr, @IsActive, @IsDeleted, 
                    @CanEdit, @CanDelete, @DisplayOrder, @Color, @Icon, @CBy, @CDate, @EBy, @EDate);
                    SELECT SCOPE_IDENTITY()";

            var newId = await connection.QueryFirstOrDefaultAsync<int>(sql, entity);
            return newId;
        }
    }


    public async Task<bool> UpdateVisitRejectReasonAsync(VisitRejectReasonModel entity)
    {
        using (var connection = _dapperContext.CreateConnection())
        {

                var sql = @"UPDATE VisitRejectReason
                   SET 
                       VisitRejectReasonCode = @VisitRejectReasonCode,
                       VisitRejectReasonNameEn = @VisitRejectReasonNameEn,
                       VisitRejectReasonNameAr = @VisitRejectReasonNameAr,
                       IsActive = @IsActive,
                       IsDeleted = @IsDeleted,
                       CanEdit = @CanEdit,
                       CanDelete = @CanDelete,
                       DisplayOrder = @DisplayOrder,
                       Color = @Color,
                       Icon = @Icon,
                       CBy = @CBy,
                       CDate = @CDate,
                       EBy = @EBy,
                       EDate = @EDate
                   WHERE VisitRejectReasonId = @VisitRejectReasonId";

                var parameters = new
                {
                    @VisitRejectReasonId = entity.VisitRejectReasonId,
                    @VisitRejectReasonCode = entity.VisitRejectReasonCode,
                    @VisitRejectReasonNameEn = entity.VisitRejectReasonNameEn,
                    @VisitRejectReasonNameAr = entity.VisitRejectReasonNameAr,
                    @IsActive = entity.IsActive,
                    @IsDeleted = entity.IsDeleted,
                    @CanEdit = entity.CanEdit,
                    @CanDelete = entity.CanDelete,
                    @DisplayOrder = entity.DisplayOrder,
                    @Color = entity.Color,
                    @Icon = entity.Icon,
                    @CBy = entity.CBy,
                    @CDate = entity.CDate,
                    @EBy = entity.EBy,
                    @EDate = entity.EDate,
                };

                var result = await connection.ExecuteAsync(sql, parameters);
                return result > 0;
            }


        }

    public async Task<bool> DeleteVisitRejectReasonAsync(int id)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var param = new
            {
                @VisitRejectReasonId = id,
            };

            var sql = @"UPDATE VisitRejectReason 
                    SET IsActive = 0 
                    WHERE VisitRejectReasonId = @VisitRejectReasonId";

            var result = await connection.ExecuteAsync(sql, param);
            return result > 0;
        }
    }

}


