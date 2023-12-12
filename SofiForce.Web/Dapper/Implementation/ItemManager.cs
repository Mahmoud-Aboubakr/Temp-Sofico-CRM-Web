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
                    @ItemId = searchModel.ItemId,
                    @ItemName = searchModel.ItemName,
                    @ItemCode = searchModel.ItemCode,
                    @VendorId = searchModel.VendorId,
                    @PublicPrice = searchModel.PublicPrice,
                    @ClientPrice = searchModel.ClientPrice,
                    @IsNewAdded = searchModel.IsNewAdded == 0 ? "" : searchModel.IsNewAdded.ToString(),
                    @HasPromotion = searchModel.HasPromotion,
                    @IsActive = searchModel.IsActive == 0 ? "" : searchModel.IsActive.ToString(),
                    @IsNewStocked = searchModel.IsNewStocked == 0 ? "" : searchModel.IsNewStocked.ToString(),
                    @Skip = searchModel.Skip,
                    @Take = searchModel.Take,
                    @Term = searchModel.Term,
                    @FilterBy = searchModel.FilterBy,
                    @StoreId = searchModel.StoreId,
                    @SortBy = searchModel.SortBy,
                    @TermBy = searchModel.TermBy,
                };
                model = connection.Query<ItemListModel>
                    ("GetItemWithLatestPromotion", // storeprocedure here
                    param, commandType: System.Data.CommandType.StoredProcedure
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
