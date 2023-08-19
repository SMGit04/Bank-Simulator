# Bank Simulator

This Rest API simulatres the processes a bank would normaly take to valiadate a transaction.
The API receives a payload from a Java application which simulates a Point of Sale (POS) machine, the API then sends a response back to the POS machine on whether the transaction was "Approved" or "Declined" through the "TransactionStatus" endpoint.

The API has another endpointt "NotificationHub" which will be used to send notificatio to the user Android application
The API communicates with a front end facing Java application which demonstrates the bank application a user would have.

The API is still being continously developed :)
