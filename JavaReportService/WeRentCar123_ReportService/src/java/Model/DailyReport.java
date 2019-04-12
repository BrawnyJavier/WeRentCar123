/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author brawn
 */
@Entity
@Table(name = "DailyReport")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "DailyReport.findAll", query = "SELECT d FROM DailyReport d")
    , @NamedQuery(name = "DailyReport.findByDate", query = "SELECT d FROM DailyReport d WHERE d.date = :date")
    , @NamedQuery(name = "DailyReport.findByIncome", query = "SELECT d FROM DailyReport d WHERE d.income = :income")
    , @NamedQuery(name = "DailyReport.findByCarsRented", query = "SELECT d FROM DailyReport d WHERE d.carsRented = :carsRented")})
public class DailyReport implements Serializable {

    private static final long serialVersionUID = 1L;
    @Column(name = "DATE")
    @Temporal(TemporalType.DATE)
    private Date date;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Column(name = "INCOME")
    private BigDecimal income;
    @Column(name = "CARS_RENTED")
    private Integer carsRented;

    public DailyReport() {
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public BigDecimal getIncome() {
        return income;
    }

    public void setIncome(BigDecimal income) {
        this.income = income;
    }

    public Integer getCarsRented() {
        return carsRented;
    }

    public void setCarsRented(Integer carsRented) {
        this.carsRented = carsRented;
    }
    
}
