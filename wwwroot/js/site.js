function updateProgressBar() {
    var activeTab = $('.tab-pane.show.active').index();
    $('.progress-step').removeClass('completed');
    for (var i = 0; i <= activeTab; i++) {
        $('.progress-step').eq(i).addClass('completed');
    }
}

function nextTab(tabId) {
    $('.tab-pane').removeClass('show active');
    $(tabId).addClass('show active');

    updateProgressBar();
}

function prevTab(tabId) {
    $('.tab-pane').removeClass('show active');
    $(tabId).addClass('show active');
    updateProgressBar();
}

//submit button in application when clicked

function bt() {
    const button = document.getElementById('submitbtn');

    button.addEventListener('click', () => {
        // Toggle the 'clicked' class
        button.classList.toggle('clicked');
    });

}

function addExperience() {
    // Get the experience container
    const experienceContainer = document.getElementById('experienceContainer');

    // Clone the initial experience section
    const initialSection = document.getElementById('initialExperienceSection');
    const newSection = initialSection.cloneNode(true);

    // Clear the values of the new section
    Array.from(newSection.querySelectorAll('input')).forEach(input => {
        input.value = '';
        input.removeAttribute('id'); // Clear the id to avoid duplicate ids
    });

    // Add a Remove button to the new section
    const removeButton = document.createElement('text');
    removeButton.type = 'button';
    removeButton.className = 'btn btn-danger remove-experience';
    removeButton.textContent = 'Remove';
    removeButton.onclick = function () {
        removeExperience(this);
    };

    // Append the remove button to the new section
    newSection.appendChild(removeButton);

    // Append the cloned section to the container
    experienceContainer.appendChild(newSection);
}

function removeExperience(button) {
    const section = button.closest('.experience-section');
    if (section && !section.isSameNode(document.getElementById('initialExperienceSection'))) {
        section.remove();
    }
}

function addCertification() {
    // Get the certifications container
    const certificationsContainer = document.getElementById('certificationsContainer');

    // Clone the initial certification section
    const initialSection = document.getElementById('certificationSection1');
    const newSection = initialSection.cloneNode(true);

    // Clear the values and update IDs of the new section
    Array.from(newSection.querySelectorAll('input')).forEach(input => {
        input.value = '';
        input.removeAttribute('id'); // Clear the id to avoid duplicate ids
        // Update names as well to ensure no conflicts
        input.name = input.name.replace(/\d+$/, '') + (certificationsContainer.children.length + 1);
    });

    // Create and add the Remove button to the new section
    const removeButton = document.createElement('button');
    removeButton.type = 'button';
    removeButton.className = 'btn btn-danger remove-certification';
    removeButton.textContent = 'Remove';
    removeButton.onclick = function () {
        removeCertification(this);
    };

    // Append the Remove button to the new section
    newSection.appendChild(removeButton);

    // Append the cloned section to the container
    certificationsContainer.appendChild(newSection);
}

function removeCertification(button) {
    const section = button.closest('.certification-section');
    if (section && !section.isSameNode(document.getElementById('certificationSection1'))) {
        section.remove();
    }
}
