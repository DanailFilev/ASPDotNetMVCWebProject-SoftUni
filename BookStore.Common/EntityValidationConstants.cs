namespace BookStore.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class EntityValidationConstants
    {
        public static class Author
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 50;

            public const int BiographyMinLength = 10;
            public const int BiographyMaxLength = 1000;

        }

        public static class Book
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 255;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 50;

            public const int BiographyMinLength = 10;
            public const int BiographyMaxLength = 1000;

            public const int AuthorMinLength = 2;
            public const int AuthorMaxLength = 100;

            public const int GenreMinLength = 2;
            public const int GenreMaxLength = 150;

            public const string PriceType = "decimal(18, 2)";

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 1000;

            public const int StockQuantityMinValue = 0;
        }

        public static class Genre
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Order
        {
            public const double TotalAmountMinValue = 0.01;
            public const string TotalAmountType = "decimal(18, 2)";
        }

        public static class CartItem
        {
            public const int QuantityMinValue = 1;
        }

        public static class OrderItem
        {
            public const int QuantityMinValue = 1;
            public const string UnitPriceType = "decimal(18, 2)";
        }

        public static class Review
        {
            public const int CommentMinLength = 1;
            public const int CommentMaxLength = 1000;

            public const int RatingMinValue = 1;
            public const int RatingMaxValue = 10;
        }
    }
}
