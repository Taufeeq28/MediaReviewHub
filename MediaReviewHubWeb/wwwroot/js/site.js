$(document).ready(function () {
    // DataTable initialization
    var table = $('#myTable').DataTable({
        "scrollY": "900px",
        "scrollCollapse": true,
        "paging": true,
    });

    // Function to fetch movies from TVMaze
    function fetchMovies(query) {
        return fetch(`https://api.tvmaze.com/search/shows?q=${query}`)
            .then(response => response.json())
            .then(data => data.map(movie => ({ name: movie.show.name, category: 'Movies' }))) // Changed to 'Movies'
            .catch(error => console.error('Error fetching movie data:', error));
    }

    // Function to fetch books from Open Library
    function fetchBooks(query) {
        return fetch(`https://openlibrary.org/search.json?title=${query}`)
            .then(response => response.json())
            .then(data => data.docs.slice(0, 6).map(book => ({ name: book.title, category: 'Books' }))) // Changed to 'Books'
            .catch(error => console.error('Error fetching book data:', error));
    }

    // Autocomplete for the Title input field (Books and Movies)
    $('#titleInput').on('input', function () {
        var query = $(this).val();
        var suggestionBox = $('#movieSuggestions');

        if (query.length > 2) {
            // Fetch both movies and books
            Promise.all([fetchMovies(query), fetchBooks(query)])
                .then(results => {
                    // Combine movies and books results
                    var combinedResults = [...results[0], ...results[1]];

                    suggestionBox.empty(); // Clear previous suggestions

                    // Append each result with category label
                    combinedResults.forEach(item => {
                        suggestionBox.append(
                            `<li style="padding: 10px; font-size: 16px; cursor: pointer; display: flex; justify-content: space-between;">
                                <span>${item.name}</span> 
                                <span style="font-weight: bold; color: gray;">(${item.category})</span>
                            </li>`
                        );
                    });

                    // Show the suggestions list
                    suggestionBox.show();
                })
                .catch(error => console.error('Error fetching data:', error));
        } else {
            suggestionBox.empty().hide(); // Hide the suggestion box if fewer than 3 characters are typed
        }
    });

    // Handle suggestion click event
    $('#movieSuggestions').on('click', 'li', function () {
        var selectedTitle = $(this).children('span:first-child').text();
        var selectedCategory = $(this).children('span:last-child').text().replace(/[()]/g, '');

        // Set the selected title in the input field
        $('#titleInput').val(selectedTitle);

        // Automatically select the category based on the selected suggestion
        $('#categorySelect').val(selectedCategory); // This will now work since categories match

        // Hide the suggestions list
        $('#movieSuggestions').empty().hide();
    });

    // Hide the suggestions if clicked outside the input or suggestions list
    $(document).on('click', function (event) {
        if (!$(event.target).closest('#titleInput, #movieSuggestions').length) {
            $('#movieSuggestions').hide();
        }
    });
});
