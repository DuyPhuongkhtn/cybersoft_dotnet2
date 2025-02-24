window.scrollToTop = () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    })
};

function showFeedbackModal() {
    var feedbackModal = new bootstrap.Modal(document.getElementById('feedbackModal'));
    feedbackModal.show();
}