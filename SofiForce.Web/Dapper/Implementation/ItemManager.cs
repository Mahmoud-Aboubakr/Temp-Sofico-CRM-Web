using Dapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.DataObjects;
using SofiForce.Web.Dapper.Interface;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace SofiForce.Web.Dapper.Implementation;

public class ItemManager : IItemManager
{
	private readonly DapperContext _context;

    public ItemManager(DapperContext context)
    {
        _context = context;
    }


    public List<ItemListModel> filter(ItemSearchModel searchModel)
    {
        List<ItemListModel> model = new List<ItemListModel>();
        try
		{
            using (var connection = _context.CreateConnection())
            {
                var param = new
                {
                    @VendorId = searchModel.VendorId,
                    @HasPromotion = searchModel.HasPromotion == null ? "" : searchModel.HasPromotion.ToString(),
                    @IsActive = searchModel.IsActive == null ? "" : searchModel.IsActive.ToString(),
                    @PageNumber = searchModel.Skip + 1,
                    @PageSize = searchModel.Take,
                    @Term = searchModel.Term,
                    @StoreId = searchModel.StoreId,
                    @SearchTermBy = searchModel.TermBy,
                };
                model = connection.Query<ItemListModel>
                    ("GetItemWithLatestPromotion", // storeprocedure here
                    param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout:120
                    ).ToList();

            }
        }
		catch (System.Exception)
		{

			throw;
		}
        return model;
    }


}
