document.addEventListener('DOMContentLoaded', function () {
    var ctx = document.getElementById('genderChart').getContext('2d');
    var totalMaleApplicants = parseInt(document.getElementById('genderChart').dataset.male);
    var totalFemaleApplicants = parseInt(document.getElementById('genderChart').dataset.female);

    var genderChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ['Male', 'Female'],
            datasets: [{
                label: 'Gender Distribution',
                data: [totalMaleApplicants, totalFemaleApplicants],
                backgroundColor: ['#007bff', '#ff5733'],
                borderWidth: 1
            }]
        },
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
});
