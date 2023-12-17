using Models;
using System.Collections.Generic;

namespace SofiForce.Web.Dapper.Interface;

public interface IItemManager
{
    List<ItemListModel> filter(ItemSearchModel searchModel);
    List<ItemListModel> filterItem(ItemSearchModel searchModel);
    List<ItemListModel> filterAllItem(ItemSearchModel searchModel);
}
