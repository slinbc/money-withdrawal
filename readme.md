EN :
This application simulates a money withdrawal on an account number in a fake, simplistic way

***

Already Implemented :
- During a withdrawal, if the withdrawn amount would bring the corresponding account's balance under zero : blocks the operation and displays the following message : "Le montant de la demande dépasse le solde du compte".
- During a withdrawal, if the withdrawn amount is inferior to the corresponding account's balance : proceeds with the operation, registers the account's new balance and displays the following message : "Vous venez de retirer XXX sur votre compte n° YYY" (XXX being the withdrawn amount and YYY the account number on which the withdrawal was performed).

***

To Do :
- Cover the existing code with tests
- Implement the notion of overdraft, with the following rules :
1. During a withdrawal, if the withdrawn amount would bring the corresponding account's balance under (zero minus the overdraft amount allowed for this account) : blocks the operation and displays a message : "Le montant de la demande dépasse votre autorisation de découvert".
2. During a withdrawal, if (the corresponding account's balance minus the withdrawn amount) would still be greater than (zero minus the overdraft amount allowed for this account), proceeds with the operation, registers the account's balance accordingly and displays the following message : "Vous venez de retirer XXX sur votre compte n° YYY" (XXX being the withdrawn amount and YYY the account number on which the withdrawal was performed).
- Every withdrawal performed on December should be rejected with the following message : "Aucun retrait n'est autorisé en Décembre".
- Cover the implemented code with tests

***
***
***

FR :
Cette application simule un retrait d'argent sur un numéro de compte de manière factice et simpliste.

***

Déjà Implémenté :
- Pendant un retrait, si le montant retiré devait faire passer le solde du compte correspondant sous zéro : bloque l'opération et affiche le message suivant : "Le montant de la demande dépasse le solde du compte".
- Pendant un retrait, si le montant retiré est inférieur au solde du compte correspondant : autorise l'opération, enregistre le nouveau solde du compte et affiche le message suivant : "Vous venez de retirer XXX sur votre compte n° YYY" (XXX étant le montant retiré et YYY le numéro du compte sur lequel le retrait a été réalisé).

***

A Faire :
- Couvrir le code existant par des tests
- Implémenter la notion de découvert, avec les règles suivantes :
1. Pendant un retrait, si le montant retiré devait faire passer le solde du compte sous (zéro moins le montant de l'autorisation de découvert pour ce compte) : bloque l'opération et affiche le message suivant : "Le montant de la demande dépasse votre autorisation de découvert".
2. Pendant un retrait, si (le solde du compte moins le montant retiré) serait toujours supérieur à (zéro moins le montant de l'autorisation de découvert pour ce compte) :
autorise l'opération, enregistre le nouveau solde du compte et affiche le message suivant : "Vous venez de retirer XXX sur votre compte n° YYY" (XXX étant le montant retiré et YYY le numéro du compte sur lequel le retrait a été réalisé).
- Toutes les demandes de retrait faites en Décembre doit être rejetée avec le message suivant : "Aucun retrait n'est autorisé en Décembre".
- Couvrir le code implémenté par des tests
