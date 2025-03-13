namespace HealthSync.Domain.DTOs;

public record JwtDTO(string Issuer, string Audience, string Key);
