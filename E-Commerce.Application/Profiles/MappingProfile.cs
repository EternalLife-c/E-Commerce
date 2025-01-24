using AutoMapper;
using E_Commerce.Application.DTOs.Cart;
using E_Commerce.Application.DTOs.CartItem;
using E_Commerce.Application.DTOs.Category;
using E_Commerce.Application.DTOs.Comment;
using E_Commerce.Application.DTOs.Order;
using E_Commerce.Application.DTOs.OrderItem;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Application.DTOs.Transaction;
using E_Commerce.Application.DTOs.User;
using E_Commerce.Application.DTOs.Wallet;
using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Cart
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<Cart, CreateCartDto>().ReverseMap();
            CreateMap<Cart, UpdateCartDto>().ReverseMap();
            #endregion

            #region CartItem
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<CartItem, CreateCartItemDto>().ReverseMap();
            CreateMap<CartItem, UpdateCartItemDto>().ReverseMap();
            #endregion

            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            #endregion

            #region Comment
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            #endregion

            #region Order
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            #endregion

            #region OrderItem
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, UpdateOrderItemDto>().ReverseMap();
            #endregion

            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            #endregion

            #region Transaction
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<Transaction, CreateTransactionDto>().ReverseMap();
            CreateMap<Transaction, UpdateTransactionDto>().ReverseMap();
            #endregion

            #region User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            #endregion

            #region Wallet
            CreateMap<Wallet, WalletDto>().ReverseMap();
            CreateMap<Wallet, CreateWalletDto>().ReverseMap();
            CreateMap<Wallet, UpdateWalletDto>().ReverseMap();
            #endregion
        }
    }
}