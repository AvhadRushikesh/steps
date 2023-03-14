using steps.MVVM.Models;

namespace steps.Selector
{
    public class ProductDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var fav = item as Movies;
            if (!fav.isFavorite)
            {
                Application
                    .Current
                    .Resources
                    .TryGetValue("NotFavoriteStyle", out var favoriteStyle);
                return favoriteStyle as DataTemplate;
            }
            else
            {
                Application
                    .Current
                    .Resources
                    .TryGetValue("FavoriteStyle", out var favoriteStyle);
                return favoriteStyle as DataTemplate;
            }
        }
    }
}