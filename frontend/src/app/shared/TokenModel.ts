export interface TokenModel{
    'User.Name': string,
    'User.AccountId': string,
    'User.ClientId': string,
    'User.DocumentNumber': string,
    role: string[],
    nbf: number,
    exp: number,
    iat: number,
    expirationFormated: Date,
    refreshTokenInMS: number
}