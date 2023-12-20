using Models;
using System.Collections.Generic;

namespace SofiForce.Web.Dapper.Interface;

public interface IItemManager
{
    List<ItemListModel> filter(ItemSearchModel searchModel, string sortTermBy);
    List<ItemListModel> filterItem(ItemSearchModel searchModel, string sortTermBy);
    List<ItemListModel> filterAllItem(ItemSearchModel searchModel, string sortTermBy);
}
