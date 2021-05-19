using AutoMapper;
using CrowdExpress.Models;
using CrowdExpress.Models.DTOs;
using CrowdExpress.Models.ViewModels;

namespace CrowdExpress.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //newsletter mapping
            CreateMap<Newsletter, NewsletterViewModel>()
                .ReverseMap();
            CreateMap<Newsletter, NewsletterDTO>()
                .ReverseMap();
           
            //user mapping
            CreateMap<User, RegisterViewModel>()
                .ReverseMap();
            CreateMap<User, UserDTO>()
                .ReverseMap();

            //product mapping
            CreateMap<Product, ProductViewModel>()
                .ReverseMap();
            CreateMap<Product, ProductDTO>()
                .ReverseMap();

            //order mapping
            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
            CreateMap<Order, OrderDTO>()
                .ReverseMap();

            //transactions mapping
            CreateMap<Transaction, TransactionViewModel>()
                .ReverseMap();
            CreateMap<Transaction, TransactionDTO>()
                .ReverseMap();

            //receipient mapping
            CreateMap<Receipient, ReceipientViewModel>()
                .ReverseMap();
            CreateMap<Receipient, ReceipientDTO>()
                .ReverseMap();

            //itinerary mapping
            CreateMap<Itinerary, ItineraryViewModel>()
                .ReverseMap();
            CreateMap<Itinerary, ItineraryDTO>()
                .ReverseMap();

            //wallet transaction mapping
            CreateMap<WalletTransaction, WalletTransactionViewModel>()
                .ReverseMap();
            CreateMap<WalletTransaction, WalletTransactionDTO>()
                .ReverseMap();


        }
    }
}
