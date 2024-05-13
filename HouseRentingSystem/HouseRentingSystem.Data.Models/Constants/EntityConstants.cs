namespace HouseRentingSystem.Data.Models.Constants
{
    public static class EntityConstants
    {
        public const string DefaultPassword = "123456";

        public static class HouseConstants
        {
            public const int TitleMaxLength = 50;
            public const int AddressMaxLength = 150;
            public const int DescriptionMaxLength = 500;
            public const int PricePerMonthMaxValue = 2000;
            public const int PricePerMonthMinValue = 0;
        }

        public static class AgentConstants
        {
            public const int PhoneNumberMaxLength = 15;
        }

        public static class CategoryConstants
        {
            public const int NameMaxLength = 50;
        }
    }
}
