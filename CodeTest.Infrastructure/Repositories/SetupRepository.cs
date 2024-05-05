using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Infrastructure.Repositories;
public static class SetupRepository
{
    public static string BaseSetupScript { get; private set; } = """ 
        DELETE FROM [OrderRow];
        DELETE FROM [Order];
        DELETE FROM [Customer];
        DELETE FROM [Article];

        INSERT INTO [Article] ([ArticleId], [Description], [Price])
        VALUES
        (1, 'Memory Foam Pillow', 499),
        (2, 'Pawn-ticket for chocolate', 5),
        (3, 'Bluetooth Earbuds', 789),
        (4, 'Brand New Toilet and sewer', 599),
        (5, 'Bamboo Charcoal Air Purifier', 299),
        (6, 'Smart Fitness Tracker', 1299),
        (7, 'Non-Stick Ceramic Cookware Set', 1679),
        (8, 'Chili con carne', 5763),
        (9, 'Waterproof Backpack', 2349),
        (10, 'Coke bottle with suspicious substance', 2349);

        INSERT INTO [Customer] ([CustomerNumber], [CustomerName]) 
        VALUES 
        (1, 'Lasse BOI'),
        (2, 'Michael Rodriguez'),
        (3, 'Sarah Williams'),
        (4, 'David Martinez'),
        (5, 'Jessica Brown'),
        (6, 'Christopher Lee'),
        (7, 'Amanda Taylor'),
        (8, 'Matthew Garcia'),
        (9, 'Ashley Thomas'),
        (10, 'Joshua Hernandez');

        INSERT INTO [Order] ([OrderId], [CustomerNumber])
        VALUES
        (1, 1),
        (2, 7);

        INSERT INTO [OrderRow] ([Id], [OrderId], [ArticleId], [Amount])
        VALUES
        (1, 1, 1, 3),
        (2, 1, 9, 1),
        (3, 1, 8, 1),
        (4, 2, 3, 1),
        (5, 2, 4, 4);
    """;
}
