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

    public async Task<IEnumerable<GetVisitRejectReasonModel>> GetAllVisitRejectReasonASync()
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var sql = @"SELECT * FROM VisitRejectReason WHERE IsDeleted = 0";
            var result = await connection.QueryAsync<GetVisitRejectReasonModel>(sql);
            return result;
        }
    }


    public async Task<GetVisitRejectReasonModel> GetVisitRejectReasonByIdAsync(int id)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var param = new
            {
                @VisitRejectReasonId = id,
            };
            var sql = @"SELECT * FROM VisitRejectReason WHERE VisitRejectReasonId = @VisitRejectReasonId";

            var entity = await connection.QueryFirstOrDefaultAsync<GetVisitRejectReasonModel>(sql, param);
            return entity;
        }
    }

    public async Task<int> CreateVisitRejectReasonAsync(CreateVisitRejectReasonModel entity, int userId)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var sql = @"INSERT INTO VisitRejectReason 
                                (VisitRejectReasonCode, VisitRejectReasonNameEn, VisitRejectReasonNameAr, IsActive, IsDeleted, 
                                CanEdit, CanDelete, DisplayOrder, Color, Icon, CBy, CDate)
                                VALUES 
                                (@VisitRejectReasonCode, @VisitRejectReasonNameEn, @VisitRejectReasonNameAr, 
                                @IsActive, @IsDeleted, @CanEdit, @CanDelete, @DisplayOrder, @Color, @Icon, @CBy, @CDate);
                                SELECT SCOPE_IDENTITY();
                            ";

            var parameters = new
            {
                @VisitRejectReasonCode = entity.VisitRejectReasonCode,
                @VisitRejectReasonNameEn = entity.VisitRejectReasonNameEn,
                @VisitRejectReasonNameAr = entity.VisitRejectReasonNameAr,
                @IsActive = true,
                @IsDeleted = false,
                @CanEdit = entity.CanEdit,
                @CanDelete = entity.CanDelete,
                @DisplayOrder = entity.DisplayOrder,
                @Color = entity.Color,
                @Icon = entity.Icon,
                @CBy = userId,
                @CDate = DateTime.Now,
                //@EBy = entity.EBy,
                //@EDate = entity.EDate,
            };


            var newId = await connection.QueryFirstOrDefaultAsync<int>(sql, parameters);
            return newId;

        }
    }


    public async Task<bool> UpdateVisitRejectReasonAsync(UpdateVisitRejectReasonModel entity, int userId)
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
                       EBy = @EBy,
                       EDate = @EDate
                   WHERE VisitRejectReasonId = @VisitRejectReasonId";

                var parameters = new
                {
                    @VisitRejectReasonId = entity.VisitRejectReasonId,
                    @VisitRejectReasonCode = entity.VisitRejectReasonCode,
                    @VisitRejectReasonNameEn = entity.VisitRejectReasonNameEn,
                    @VisitRejectReasonNameAr = entity.VisitRejectReasonNameAr,
                    @IsActive = true,
                    @IsDeleted = false,
                    @CanEdit = entity.CanEdit,
                    @CanDelete = entity.CanDelete,
                    @DisplayOrder = entity.DisplayOrder,
                    @Color = entity.Color,
                    @Icon = entity.Icon,
                    //@CBy = entity.CBy,
                    //@CDate = entity.CDate,
                    @EBy = userId,
                    @EDate = DateTime.Now,
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


