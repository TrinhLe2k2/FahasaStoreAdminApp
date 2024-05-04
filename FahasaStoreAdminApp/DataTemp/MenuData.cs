using FahasaStoreAPI.Models.FormModels;
using System;

namespace FahasaStoreAdminApp.DataTemp
{
    public class MenuData
    {

        public List<MenuForm> menus { get; }

        public MenuData()
        {
            menus = [];
            for (int i = 1; i < 13; i++)
            {
                string urlImage = "/image/MenuImage/lf" + i + ".png";
                MenuForm menu = new(i, "Menu" + i, "#", urlImage);
                menus.Add(menu);
            }
        }

        public MenuForm? Menu(int id)
        {
            var menu = menus.SingleOrDefault(e => e.MenuId == id);
            return menu;
        }

        public IEnumerable<MenuForm> ListMenus()
        {
            return menus;
        }
    }
}
