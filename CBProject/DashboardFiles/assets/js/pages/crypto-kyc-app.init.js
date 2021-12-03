try {
    $(document).ready(function () { $("#kyc-verify-wizard").steps({ headerTag: "h3", bodyTag: "section", transitionEffect: "slide" }) });
} catch (error) {
    console.log(`Error: ${error}`);
}