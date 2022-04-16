using System;

namespace PcAccessories.Ultilities
{
    public class PcAccessoriesEnum
    {
        public enum SlideStatus : byte
        {
            InActive,
            Active
        } 

        public enum UserStatus : byte
        {
            InActive,
            Active
        }

        public enum ProductStatus : byte
        {
            New
        }
    }
}
