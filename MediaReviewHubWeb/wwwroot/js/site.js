$(document).ready(function () {
    // Initialize DataTable
    var table = $('#myTable').DataTable({
        "scrollY": "900px",
        "scrollCollapse": true,
        "paging": true,
        
    });

    // Apply filters automatically on checkbox change
    $("input[name='categoryFilter']").on('change', function () {
        var selectedCategories = [];

        // Collect selected categories
        $("input[name='categoryFilter']:checked").each(function () {
            selectedCategories.push($(this).val());  // Get all selected categories
        });

        // Use regex to filter the DataTable based on selected categories
        if (selectedCategories.length > 0) {
            var regex = selectedCategories.join('|'); // Create a regex pattern from the selected categories (Movies|Books|Music|Games)
            table.column(1).search(regex, true, false).draw(); // Filter column 1 (Category column) using regex
        } else {
            table.column(1).search('').draw(); // If no category is selected, show all rows
        }
    });
});
