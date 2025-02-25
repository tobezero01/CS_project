using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_Final.Models;

namespace Test_Final.Services
{
	public interface IBookInventoryService
	{
		/// <summary>
		/// Gets the book asynchronously.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the book if found; otherwise, null.</returns>
		Task<Book?> GetBookAsync(int id);

		/// <summary>
		/// Adds the book asynchronously.
		/// </summary>
		/// <param name="book">The book.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		Task AddBookAsync(Book book);

		/// <summary>
		/// Removes the book asynchronously.
		/// </summary>
		/// <param name="book">The book.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		Task RemoveBookAsync(Book book);

		/// <summary>
		/// Displays the books asynchronously.
		/// </summary>
		/// <returns>A task that represents the asynchronous operation.</returns>
		Task DisplayBooksAsync();

		/// <summary>
		/// Searches the book asynchronously.
		/// </summary>
		/// <param name="keyword">The keyword.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the list of matching books.</returns>
		Task<List<Book>> SearchBookAsync(string keyword);

		/// <summary>
		/// Updates the book asynchronously.
		/// </summary>
		/// <param name="book">The book.</param>
		/// <param name="quantity">The quantity.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the updated book and its new quantity if successful.</returns>
		Task<(Book, int)?> UpdateBookAsync(Book book, int quantity);

		/// <summary>
		/// Sorts the books asynchronously.
		/// </summary>
		/// <param name="comparison">The comparison delegate.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the sorted list of books.</returns>
		Task<List<Book>> SortBooksAsync(Comparison<Book> comparison);

		/// <summary>
		/// Exports all books in the inventory to a JSON file.
		/// </summary>
		/// <param name="filePath">The file path where the JSON file will be saved.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		Task ExportToJsonAsync(string filePath);

		/// <summary>
		/// Imports books from a JSON file and adds only those that do not already exist (based on ISBN).
		/// </summary>
		/// <param name="filePath">The file path from where to import the JSON file.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		Task ImportFromJsonAsync(string filePath);

		/// <summary>
		/// Exports all books in the inventory to an Excel file.
		/// </summary>
		/// <param name="filePath">The file path where the Excel file will be saved.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		Task ExportToExcelAsync(string filePath);

		/// <summary>
		/// Imports books from an Excel file and adds only those that do not already exist (based on ISBN).
		/// </summary>
		/// <param name="filePath">The file path from where to import the Excel file.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		Task ImportFromExcelAsync(string filePath);

		/// <summary>
		/// Gets all books asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<List<Book>> GetAllBooksAsync();
	}
}

/*
 * using System;
using System.Collections.Generic;
using Test_Final.Models;

namespace Test_Final.Services
{
    public interface IBookInventoryService
    {
        /// <summary>
        /// Gets the book by its identifier.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns>The book if found; otherwise, null.</returns>
        Book? GetBook(int id);

        /// <summary>
        /// Adds a book to the inventory.
        /// </summary>
        /// <param name="book">The book to add.</param>
        void AddBook(Book book);

        /// <summary>
        /// Removes a book from the inventory.
        /// </summary>
        /// <param name="book">The book to remove.</param>
        void RemoveBook(Book book);

        /// <summary>
        /// Displays all books in the inventory.
        /// </summary>
        void DisplayBooks();

        /// <summary>
        /// Searches for books containing the given keyword.
        /// </summary>
        /// <param name="keyword">The keyword to search for.</param>
        /// <returns>A list of matching books.</returns>
        List<Book> SearchBook(string keyword);

        /// <summary>
        /// Updates the quantity of a book in the inventory.
        /// </summary>
        /// <param name="book">The book to update.</param>
        /// <param name="quantity">The new quantity.</param>
        /// <returns>The updated book and its new quantity if successful; otherwise, null.</returns>
        (Book, int)? UpdateBook(Book book, int quantity);

        /// <summary>
        /// Sorts the books in the inventory.
        /// </summary>
        /// <param name="comparison">The comparison delegate.</param>
        /// <returns>The sorted list of books.</returns>
        List<Book> SortBooks(Comparison<Book> comparison);

        /// <summary>
        /// Exports all books in the inventory to a JSON file.
        /// </summary>
        /// <param name="filePath">The file path where the JSON file will be saved.</param>
        void ExportToJson(string filePath);

        /// <summary>
        /// Imports books from a JSON file, adding only those that do not already exist (based on ISBN).
        /// </summary>
        /// <param name="filePath">The file path of the JSON file.</param>
        void ImportFromJson(string filePath);

        /// <summary>
        /// Exports all books in the inventory to an Excel file.
        /// </summary>
        /// <param name="filePath">The file path where the Excel file will be saved.</param>
        void ExportToExcel(string filePath);

        /// <summary>
        /// Imports books from an Excel file, adding only those that do not already exist (based on ISBN).
        /// </summary>
        /// <param name="filePath">The file path of the Excel file.</param>
        void ImportFromExcel(string filePath);

        /// <summary>
        /// Retrieves all books from the inventory.
        /// </summary>
        /// <returns>A list of all books.</returns>
        List<Book> GetAllBooks();
    }
}

 */