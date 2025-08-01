// assets/js/copy-code.js
document.addEventListener("DOMContentLoaded", function() {
  const codeBlocks = document.querySelectorAll("pre.highlight"); // Or your specific code block selector
  const copyCodeButtons = document.querySelectorAll('.copy-code-button');

  copyCodeButtons.forEach((copyCodeButton, index) => {
    const code = codeBlocks[index].innerText;

    copyCodeButton.addEventListener('click', () => {
      // Copy the code to the user's clipboard
      window.navigator.clipboard.writeText(code);

      // Update the button text visually
      const { src: originalText } = copyCodeButton;
      console.log(originalText);
      copyCodeButton.src = originalText.replace('copy', 'check-lg'); // Change the icon to indicate success
      copyCodeButton.classList.add('copied'); // Add a class for any additional styling if needed
      console.log(copyCodeButton.src);


      // After 2 seconds, reset the button to its initial UI
      setTimeout(() => {
        copyCodeButton.src = originalText;
        copyCodeButton.classList.remove('copied');
      }, 2000);
    });
  })
});