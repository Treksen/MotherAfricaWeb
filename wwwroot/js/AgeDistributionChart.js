document.addEventListener('DOMContentLoaded', function () {
    initializeAgeChart();
});

function initializeAgeChart() {
    // Get the canvas element by ID
    var ctx = document.getElementById('ageChart').getContext('2d');

    // Data for the age distribution chart
    var ageData = {
        labels: ['18-25', '26-35', '36-45', '46-55', '56+'], // Age groups
        datasets: [{
            label: 'Age Distribution',
            data: [
                parseInt(document.getElementById('age18To25').value),
                parseInt(document.getElementById('age26To35').value),
                parseInt(document.getElementById('age36To45').value),
                parseInt(document.getElementById('age46To55').value),
                parseInt(document.getElementById('age56Plus').value)
            ],
            backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0', '#9966FF'], // Different colors for the chart sections
            borderWidth: 1
        }]
    };

    // Create a new pie chart
    var ageChart = new Chart(ctx, {
        type: 'pie',
        data: ageData,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                tooltip: {
                    callbacks: {
                        label: function (tooltipItem) {
                            return tooltipItem.label + ': ' + tooltipItem.raw + ' Applicants';
                        }
                    }
                }
            }
        }
    });
}
