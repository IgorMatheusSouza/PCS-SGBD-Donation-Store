﻿namespace DonationStore.Infrastructure.Constants
{
    public static class SystemConstantValues
    {
        public static readonly int GenericMaxFieldLength = 3000;

        public const int DefaultDonationsQuantityPerPage = 20;

        public const int DefaultTimeOnScopeTransactionInMinutes = 3;

        public static string HeaderUserTokenString = "userToken";

        public static string TokenViewModelString = "Token";

        public static string ImageFolder = "\\DonationImgs\\";

        public static string ImageExtension = ".jpg";
    }
}
